    public static Collection<Appointment> FindRecurringCalendarItems(ExchangeService service, 
                                                                        DateTime startSearchDate, 
                                                                        DateTime endSearchDate)
    {
        // Instantiate a collection to hold occurrences and exception calendar items.
        Collection<Appointment> foundAppointments = new Collection<Appointment>();
        // Create a calendar view to search the calendar folder and specify the properties to return.
        CalendarView calView = new CalendarView(startSearchDate, endSearchDate);
        calView.PropertySet = new PropertySet(BasePropertySet.IdOnly, 
                                                AppointmentSchema.Subject, 
                                                AppointmentSchema.IsRecurring, 
                                                AppointmentSchema.AppointmentType
                                                AppointmentSchema.Start,
                                                AppointmentSchema.Location);
        // Retrieve a collection of calendar items.
        FindItemsResults<Appointment> findResults = service.FindAppointments(WellKnownFolderName.Calendar, calView);
        // Add all calendar items in your view that are occurrences or exceptions to your collection.
        foreach (Appointment appt in findResults.Items)
        {
            if (appt.AppointmentType == AppointmentType.Occurrence || appt.AppointmentType == AppointmentType.Exception)
            {
                foundAppointments.Add(appt);
            }
            else
            {
                Console.WriteLine("Discarding calendar item of type {0}.", appt.AppointmentType);
            }
        }
        return foundAppointments;
    }
