    using (System.Xml.XmlReader xr = System.Xml.XmlTextReader.Create(stm))
    {
       employeeSchedules = new Dictionary<string, EmployeeSchedule>();
       EmployeeSchedule emp = null;
       WeekSchedule sch = null;
       TimeRanges ranges = null;
       TimeRange range = null;
       while (xr.Read())
       {
          if (xr.IsStartElement("Employee"))
          {
             emp = new EmployeeSchedule();
             employeeSchedules.Add(xr.GetAttribute("Name"), emp);
          }
          else if (xr.IsStartElement("Unavailable"))
          {
             sch = new WeekSchedule();
             emp.unavailable = sch;
          }
          else if (xr.IsStartElement("Scheduled"))
          {
             sch = new WeekSchedule();
             emp.scheduled = sch;
          }
          else if (xr.IsStartElement("DaySchedule"))
          {
             ranges = new TimeRanges();
             sch.daySchedule[int.Parse(xr.GetAttribute("DayNumber"))] = ranges;
             ranges.Color = ParseColor(xr.GetAttribute("Color"));
             ranges.FillStyle = (System.Drawing.Drawing2D.HatchStyle)
                System.Enum.Parse(typeof(System.Drawing.Drawing2D.HatchStyle),
                xr.GetAttribute("Pattern"));
          }
          else if (xr.IsStartElement("TimeRange"))
          {
             range = new TimeRange(
                System.Xml.XmlConvert.ToDateTime(xr.GetAttribute("Start"),
                System.Xml.XmlDateTimeSerializationMode.Unspecified),
                new TimeSpan((long)(System.Xml.XmlConvert.ToDouble(xr.GetAttribute("Length")) * TimeSpan.TicksPerHour)));
             ranges.Add(range);
          }
       }
       xr.Close();
    }
