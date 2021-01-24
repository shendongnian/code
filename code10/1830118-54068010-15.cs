	using Google.Apis.Auth.OAuth2;
	using Google.Apis.Calendar.v3;
	using Google.Apis.Calendar.v3.Data;
	using Google.Apis.Services;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	namespace CalendarQuickstart
	{
		class Program
		{
			static void Main(string[] args)
			{
				string jsonFile = "xxxxxxx-xxxxxxxxxxxxx.json";
				string calanderId = @"xxxxxxxxxxxxx@group.calendar.google.com";
				string[] Scopes = { CalendarService.Scope.Calendar };
				ServiceAccountCredential credential;
				using (var stream =
					new FileStream(jsonFile, FileMode.Open, FileAccess.Read))
				{
					var confg = Google.Apis.Json.NewtonsoftJsonSerializer.Instance.Deserialize<JsonCredentialParameters>(stream);
					credential = new ServiceAccountCredential(
					   new ServiceAccountCredential.Initializer(confg.ClientEmail)
					   {
						   Scopes = Scopes
					   }.FromPrivateKey(confg.PrivateKey));
				}
				var service = new CalendarService(new BaseClientService.Initializer()
				{
					HttpClientInitializer = credential,
					ApplicationName = "Calendar API Sample",
				});
				var calander = service.Calendars.Get(calanderId).Execute();
				Console.WriteLine("Calander Name :");
				Console.WriteLine(calander.Summary);
				Console.WriteLine("click for more .. ");
				Console.Read();
				// Define parameters of request.
				EventsResource.ListRequest listRequest = service.Events.List(calanderId);
				listRequest.TimeMin = DateTime.Now;
				listRequest.ShowDeleted = false;
				listRequest.SingleEvents = true;
				listRequest.MaxResults = 10;
				listRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
				// List events.
				Events events = listRequest.Execute();
				Console.WriteLine("Upcoming events:");
				if (events.Items != null && events.Items.Count > 0)
				{
					foreach (var eventItem in events.Items)
					{
						string when = eventItem.Start.DateTime.ToString();
						if (String.IsNullOrEmpty(when))
						{
							when = eventItem.Start.Date;
						}
						Console.WriteLine("{0} ({1})", eventItem.Summary, when);
					}
				}
				else
				{
					Console.WriteLine("No upcoming events found.");
				}
				Console.WriteLine("click for more .. ");
				Console.Read();
				var myevent = DB.Find(x => x.Id == "eventid" + 1);
				var InsertRequest = service.Events.Insert(myevent, calanderId);
				try
				{
					InsertRequest.Execute();
				}
				catch (Exception)
				{
					try
					{
						service.Events.Update(myevent, calanderId, myevent.Id).Execute();
						Console.WriteLine("Insert/Update new Event ");
						Console.Read();
					}
					catch (Exception)
					{
						Console.WriteLine("can't Insert/Update new Event ");
					}
				}
			}
			static List<Event> DB =
				 new List<Event>() {
					new Event(){
						Id = "eventid" + 1,
						Summary = "Google I/O 2015",
						Location = "800 Howard St., San Francisco, CA 94103",
						Description = "A chance to hear more about Google's developer products.",
						Start = new EventDateTime()
						{
							DateTime = new DateTime(2019, 01, 13, 15, 30, 0),
							TimeZone = "America/Los_Angeles",
						},
						End = new EventDateTime()
						{
							DateTime = new DateTime(2019, 01, 14, 15, 30, 0),
							TimeZone = "America/Los_Angeles",
						},
						 Recurrence = new List<string> { "RRULE:FREQ=DAILY;COUNT=2" },
						Attendees = new List<EventAttendee>
						{
							new EventAttendee() { Email = "lpage@example.com"},
							new EventAttendee() { Email = "sbrin@example.com"}
						}
					}
				 };
		}
	}
