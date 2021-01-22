    iCalendar iCal = new iCalendar();
    foreach (CalendarItem item in _db.CalendarItems.Where(r => r.Start > DateTime.Now && r.Active == true && r.CalendarID == ID).ToList())
    {
    	Event evt = new Event();
    	evt.Start = new iCalDateTime(item.Start);
    	evt.End = new iCalDateTime(item.End);
    	evt.Summary = "Some title";
    	evt.IsAllDay = false;
    	evt.Duration = (item.End - item.Start).Duration();
    	iCal.Events.Add(evt);
    }
    // Create a serialization context and serializer factory. 
    // These will be used to build the serializer for our object. 
    ISerializationContext ctx = new SerializationContext();
    ISerializerFactory factory = new DDay.iCal.Serialization.iCalendar.SerializerFactory();
    // Get a serializer for our object
    IStringSerializer serializer = factory.Build(iCal.GetType(), ctx) as IStringSerializer;
    if (serializer == null) return Content("");
    string output = serializer.SerializeToString(iCal);
    var contentType = "text/calendar";
    var bytes = Encoding.UTF8.GetBytes(output);
    var result = new FileContentResult(bytes, contentType);
    result.FileDownloadName = "FileName.ics";
    return result;
