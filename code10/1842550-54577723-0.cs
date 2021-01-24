    using System;
    using Ical.Net;
    using Ical.Net.CalendarComponents;
    using Ical.Net.DataTypes;
    using Ical.Net.Serialization;
    using System.Web.Http;
    using System.Net.Http;
    using System.Net;
    using System.Net.Http.Headers;
    namespace DEMO.API
    {
        public class CalendarsController : ApiController
        {
            [AllowAnonymous]
            [HttpPost]
            [Route("api/calendar")]
            public IHttpActionResult Get()
            {
                IHttpActionResult response;
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                var e = new CalendarEvent
                {
                    Start = new CalDateTime(DateTime.Now),
                    End = new CalDateTime(DateTime.Now.AddHours(1)),
                    Location = "Eric's Cube",
                    Description = "Chillin at Eric's cube. who you with? me and my peeps why you bring 4 of your friiiiiieeeends."
                };
                var calendar = new Calendar();
                calendar.Events.Add(e);
                var serializer = new CalendarSerializer();
                var serializedCalendar = serializer.SerializeToString(calendar);
                byte[] calendarBytes = System.Text.Encoding.UTF8.GetBytes(serializedCalendar);  //iCal is the calendar string
                responseMessage.Content = new ByteArrayContent(calendarBytes);
                responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("text/calendar");
                response = ResponseMessage(responseMessage);
                return response;
            }
       }
    }
