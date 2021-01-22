    var a = from m in month
            join h in holiday on m.Id equals h.MonthId
            select new
            {
                MonthId = m.Id,
                Month = m.Name,
                Holiday = h.Name,
                HolidayDay = h.DayOfMonth,
                Appointment = "",
                AppointmentDay = 0
            };
    var b = from m in month
            join p in appointments on m.Id equals p.MonthId
            select new
            {
                MonthId = m.Id,
                Month = m.Name,
                Holiday = "",
                HolidayDay = 0,
                Appointment = p.Description,
                AppointmentDay = p.DayOfMonth
            };
    var events = from o in a.Union(b)
                orderby o.MonthId, o.HolidayDay + o.AppointmentDay
                select o;
