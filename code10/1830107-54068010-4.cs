	using Google.Apis.Auth.OAuth2;
	using Google.Apis.Calendar.v3;
	using Google.Apis.Calendar.v3.Data;
	using Google.Apis.Services;
	using System;
	using System.IO;
	namespace CalendarQuickstart
	{
		class Program
		{
			static void Main(string[] args)
			{
				string jsonFile = "xxxxxxx-xxxxxxxx.json";
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
				// Define parameters of request.
				EventsResource.ListRequest request = service.Events.List("primary");
				request.TimeMin = DateTime.Now;
				request.ShowDeleted = false;
				request.SingleEvents = true;
				request.MaxResults = 10;
				request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
				// List events.
				Events events = request.Execute();
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
				Console.Read();
			}
		}
	}
