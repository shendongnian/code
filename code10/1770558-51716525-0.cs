    // Initialize values for the start and end times, and the number of appointments to retrieve.
                DateTime startDate = DateTime.Now;
                DateTime endDate = startDate.AddDays(30);
                const int NUM_APPTS = 5;
                // Initialize the calendar folder object with only the folder ID. 
                CalendarFolder calendar = CalendarFolder.Bind(service, WellKnownFolderName.Calendar, new PropertySet());
                // Set the start and end time and number of appointments to retrieve.
                CalendarView cView = new CalendarView(startDate, endDate, NUM_APPTS);
                // Limit the properties returned to the appointment's subject, start time, and end time.
                cView.PropertySet = new PropertySet(AppointmentSchema.Subject, AppointmentSchema.Start, AppointmentSchema.End);
                // Retrieve a collection of appointments by using the calendar view.
                FindItemsResults<Appointment> appointments = calendar.FindAppointments(cView);
                Console.WriteLine("\nThe first " + NUM_APPTS + " appointments on your calendar from " + startDate.Date.ToShortDateString() + 
                                  " to " + endDate.Date.ToShortDateString() + " are: \n");
            
                foreach (Appointment a in appointments)
                {
                    Console.Write("Subject: " + a.Subject.ToString() + " ");
                    Console.Write("Start: " + a.Start.ToString() + " ");
                    Console.Write("End: " + a.End.ToString());
                    Console.WriteLine();
                }
