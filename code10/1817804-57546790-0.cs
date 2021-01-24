csharp
using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using static Google.Apis.Calendar.v3.CalendarListResource.ListRequest;
/*======================================================================================
 * This file is to implement Google Calendar .NET API endpoints WITH exponential backoff.
 * 
 * How to use:
 *    - Install the Google Calendar .NET API (nuget.org/packages/Google.Apis.Calendar.v3)
 *    - In the startup of your application (or when you ask the user to authorize), call
 *      GCalAPIHelper.Instance.Auth();
 *    - Anywhere you would call the Google Calendar API (eg Get, Insert, Delete, etc),
 *      instead use this class by doing: 
 *      GCalAPIHelper.Instance.CreateEvent(event, calendarId); (you may need to expand
 *      this class to other API endpoints as your needs require) 
 *======================================================================================
 */
namespace APIHelper
{
    public class GCalAPIHelper
    {
        #region Singleton
        private static GCalAPIHelper instance;
        public static GCalAPIHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new GCalAPIHelper();
                return instance;
            }
        }
        #endregion Singleton
        #region Private Properties
        private CalendarService service { get; set; }
        private string[] scopes = { CalendarService.Scope.Calendar };
        private const string CLIENTSECRETSTRING = "YOUR_SECRET"; //Paste in your JSON client secret here. Don't forget to escape special characters!
        private const string APPNAME = "YOUR_APPLICATION_NAME"; //Paste in your Application name here
        #endregion Private Properties
        #region Constructor and Initializations
        public GCalAPIHelper()
        {
        }
        public void Auth(string credentialsPath)
        {
            if (service != null)
                return;
            UserCredential credential;
            byte[] byteArray = Encoding.ASCII.GetBytes(CLIENTSECRETSTRING);
            using (var stream = new MemoryStream(byteArray))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    scopes,
                    Environment.UserName,
                    CancellationToken.None,
                    new FileDataStore(credentialsPath, true)).Result;
            }
            service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = APPNAME
            });
        }
        #endregion Constructor and Initializations
        #region Private Methods
        private TResponse DoActionWithExponentialBackoff<TResponse>(CalendarBaseServiceRequest<TResponse> request)
        {
            return DoActionWithExponentialBackoff(request, new HttpStatusCode[0], new HttpStatusCode[0]);
        }
        private TResponse DoActionWithExponentialBackoff<TResponse>(CalendarBaseServiceRequest<TResponse> request, HttpStatusCode[] otherAllowedCodes, HttpStatusCode[] otherBackoffCodes)
        {
            int delay = 100;
            while (delay < 1000) //If the delay gets above 1 second, give up
            {
                try
                {
                    return request.Execute();
                }
                catch (GoogleApiException ex)
                {
                    if (ex.HttpStatusCode == HttpStatusCode.Forbidden || //Rate limit exceeded
                        ex.HttpStatusCode == HttpStatusCode.ServiceUnavailable || //Backend error
                        ex.HttpStatusCode == HttpStatusCode.NotFound ||
                        ex.Message.Contains("That’s an error") || //Handles the Google error pages like https://i.imgur.com/lFDKFro.png
                        otherAllowedCodes.Contains(ex.HttpStatusCode))
                    {
                        Common.Log($"Request failed. Waiting {delay} ms before trying again");
                        Thread.Sleep(delay);
                        delay += 100;
                    }
                    else
                        throw;
                }
            }
            throw new Exception("Retry attempts failed");
        }
        #endregion Private Methods
        #region Public Properties
        public bool IsAuthorized
        {
            get { return service != null; }
        }
        #endregion Public Properties
        #region Public Methods
        public Event CreateEvent(Event eventToCreate, string calendarId)
        {
            EventsResource.InsertRequest eventCreateRequest = service.Events.Insert(eventToCreate, calendarId);
            return DoActionWithExponentialBackoff(eventCreateRequest);
        }
        public Event InsertEvent(Event eventToInsert, string calendarId)
        {
            EventsResource.InsertRequest eventCopyRequest = service.Events.Insert(eventToInsert, calendarId);
            return DoActionWithExponentialBackoff(eventCopyRequest);
        }
        public Event UpdateEvent(Event eventToUpdate, string calendarId, bool sendNotifications = false)
        {
            EventsResource.UpdateRequest eventUpdateRequest = service.Events.Update(eventToUpdate, calendarId, eventToUpdate.Id);
            eventUpdateRequest.SendNotifications = sendNotifications;
            return DoActionWithExponentialBackoff(eventUpdateRequest);
        }
        public Event GetEvent(Event eventToGet, string calendarId)
        {
            return GetEvent(eventToGet.Id, calendarId);
        }
        public Event GetEvent(string eventIdToGet, string calendarId)
        {
            EventsResource.GetRequest eventGetRequest = service.Events.Get(calendarId, eventIdToGet);
            return DoActionWithExponentialBackoff(eventGetRequest);
        }
        public CalendarListEntry GetCalendar(string calendarId)
        {
            CalendarListResource.GetRequest calendarGetRequest = service.CalendarList.Get(calendarId);
            return DoActionWithExponentialBackoff(calendarGetRequest);
        }
        public Events ListEvents(string calendarId, DateTime? startDate = null, DateTime? endDate = null, string q = null, int maxResults = 250)
        {
            EventsResource.ListRequest eventListRequest = service.Events.List(calendarId);
            eventListRequest.ShowDeleted = false;
            eventListRequest.SingleEvents = true;
            eventListRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            if (startDate != null)
                eventListRequest.TimeMin = startDate;
            if (endDate != null)
                eventListRequest.TimeMax = endDate;
            if (!string.IsNullOrEmpty(q))
                eventListRequest.Q = q;
            eventListRequest.MaxResults = maxResults;
            return DoActionWithExponentialBackoff(eventListRequest);
        }
        public CalendarList ListCalendars(string accessRole)
        {
            CalendarListResource.ListRequest calendarListRequest = service.CalendarList.List();
            calendarListRequest.MinAccessRole = (MinAccessRoleEnum)Enum.Parse(typeof(MinAccessRoleEnum), accessRole);
            return DoActionWithExponentialBackoff(calendarListRequest);
        }
        public void DeleteEvent(Event eventToDelete, string calendarId, bool sendNotifications = false)
        {
            DeleteEvent(eventToDelete.Id, calendarId, sendNotifications);
        }
        public void DeleteEvent(string eventIdToDelete, string calendarId, bool sendNotifications = false)
        {
            EventsResource.DeleteRequest eventDeleteRequest = service.Events.Delete(calendarId, eventIdToDelete);
            eventDeleteRequest.SendNotifications = sendNotifications;
            DoActionWithExponentialBackoff(eventDeleteRequest, new HttpStatusCode[] { HttpStatusCode.Gone }, new HttpStatusCode[0]);
        }
        #endregion Public Methods
    }
}
