    var events =
        from
            m in GetMonths()
        groupjoin
            h in GetHolidays()
            on m.Id equals h.MonthId
            into hol = group
        from
            h in hol.DefaultIfEmpty()
        groupjoin
            a in GetAppointments()
            on m.Id equals a.MonthId
            into appt = group
        from
            a in appt.DefaultIfEmpty()
        where
            //something that narrows all combinations of events to only unique events
        orderby
            m.Id,
            // something that interleaves h.DayOfMonth with m.DayOfMonth
        select
            new
            {
                Month = m.Name,
                Holiday = h.Name,
                HolidayDay = h.DayOfMonth,
                Appointment = a.Description,
                AppointmentDay = a.DayOfMonth
            };
