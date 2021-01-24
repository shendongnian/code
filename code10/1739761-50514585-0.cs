    FindItemsResults<Item> result = service.FindItems(WellKnownFolderName.Calendar, new CalendarView(DateTime.Now, DateTime.Now.AddDays(7)));
                foreach(Item item in result.Items)
                {
                    ServiceResponseCollection<GetItemResponse> itemResponseCollection = service.BindToItems(new[] { new ItemId(item.Id.UniqueId) }, new PropertySet(BasePropertySet.FirstClassProperties));
                    foreach(GetItemResponse itemResponse in itemResponseCollection)
                    {
                        Appointment appointment = (Appointment)itemResponse.Item;
                        Console.WriteLine("Subject: " + appointment.Subject);
                        Console.WriteLine("Location: " + appointment.Location);
                        
                        Console.WriteLine("AppointmentType: " + appointment.AppointmentType.ToString());
                        Console.WriteLine("Body: " + appointment.Body);
                        Console.WriteLine("End: " + appointment.End.ToString());
                        Console.WriteLine("UniqueId: " + appointment.Id.UniqueId);
                        Console.WriteLine("Start: " + appointment.Start.ToString());
                        Console.WriteLine("When: " + appointment.When);
    
                        Console.WriteLine("Required Attendees: ");
                        foreach (var attendee in appointment.RequiredAttendees)
                        {
                            Console.WriteLine(attendee.Name);
                        }
                    }
