    const string filepath = @"C:\temp\ical.test.ics";
    // use PUBLISH for appointments
    // use REQUEST for meeting requests
    const string METHOD = "REQUEST";
    
    // Properties of the meeting request
    // keep guid in sending program to modify or cancel the request later
    Guid uid = Guid.Parse("2B127C67-73B3-43C5-A804-5666C2CA23C9");
    string VisBetreff = "This is the subject of the meeting request";
    string TerminVerantwortlicherEmail = "mr.asker@myorg.com";
    string bodyPlainText = "This is the simple iCal plain text msg";
    string bodyHtml = "This is the simple <b>iCal HTML message</b>";
    string location = "Meeting room 101";
    // 1: High
    // 5: Normal
    // 9: low
    int priority = 1;
    //=====================================
    // Plain Text Message
    MailMessage message = new MailMessage();
    
    message.From = new MailAddress("sender@myorg.com");
    message.To.Add(new MailAddress(TerminVerantwortlicherEmail));
    message.Subject = "[VIS-Termin] " + VisBetreff;
    
    // Plain Text Version
    message.Body = bodyPlainText;
    
    // HTML Version
    string htmlBody = bodyHtml;
    AlternateView HTMLV = AlternateView.CreateAlternateViewFromString(htmlBody,
      new System.Net.Mime.ContentType("text/html"));
    
    // iCal
    IICalendar iCal = new iCalendar();
    iCal.Method = METHOD;
    iCal.ProductID = "My Metting Product";            
    
    // Create an event and attach it to the iCalendar.
    Event evt = iCal.Create<Event>();
    evt.UID = uid.ToString();
    
    evt.Class = "PUBLIC";
    // Needed by Outlook
    evt.Created = new iCalDateTime(DateTime.Now);
    
    evt.DTStamp = new iCalDateTime(DateTime.Now);
    evt.Transparency = TransparencyType.Transparent;
    
    // Set the event to start at 12am, Feb 4th 2011
    evt.Start = new iCalDateTime(2014, 10, 3, 8, 0, 0); 
    evt.End = new iCalDateTime(2014, 10, 3, 8, 15, 0); 
    evt.Location = location;
    
    //var organizer = new Organizer("the.organizer@myCompany.com");
    //evt.Organizer = organizer;
    
    // Set the longer description of the event
    evt.Description = bodyPlainText;
    
    // X-ALT-DESC;FMTTYPE=text/html
    var prop = new CalendarProperty("X-ALT-DESC");
    prop.AddParameter("FMTTYPE", "text/html");
    prop.AddValue(bodyHtml);
    evt.AddProperty(prop);
    
    // Set the one-line summary of the event
    evt.Summary = VisBetreff;
    evt.Priority = priority;
    
    //--- attendes are optional
    IAttendee at = new Attendee("mailto:Peter.Black@MyOrg.com");
    at.ParticipationStatus = "NEEDS-ACTION";
    at.RSVP = true;
    at.Role = "REQ-PARTICIPANT";
    evt.Attendees.Add(at);
    
    // Let’s also add an alarm on this event so we can be reminded of it later.
    Alarm alarm = new Alarm();
    
    // Display the alarm somewhere on the screen.
    alarm.Action = AlarmAction.Display;
    
    // This is the text that will be displayed for the alarm.
    alarm.Summary = "Upcoming meeting: " + VisBetreff;
    
    // The alarm is set to occur 30 minutes before the event
    alarm.Trigger = new Trigger(TimeSpan.FromMinutes(-30));
    
    //--- Attachments
    string filename = "Test.docx";
    
    // Add an attachment to this event
    IAttachment attachment = new DDay.iCal.Attachment();
    attachment.Data = ReadBinary(@"C:\temp\Test.docx");
    attachment.Parameters.Add("X-FILENAME", filename);
    evt.Attachments.Add(attachment);
    
    iCalendarSerializer serializer = new iCalendarSerializer();
    serializer.Serialize(iCal, filepath);
    
    string iCalStr = serializer.SerializeToString(iCal);
    
    // text/calendar part: method=REQUEST
    System.Net.Mime.ContentType calendarType = 
      new System.Net.Mime.ContentType("text/calendar");
    calendarType.Parameters.Add("method", METHOD);
    AlternateView ICSview =
      AlternateView.CreateAlternateViewFromString(iCalStr, calendarType);
    
    // Compose
    message.AlternateViews.Add(HTMLV);
    message.AlternateViews.Add(ICSview); // must be the last part
    
    // Attachment
    Console.WriteLine("build mail attachment...");
    Byte[] bytes = System.Text.Encoding.ASCII.GetBytes(iCalStr);
    var ms = new System.IO.MemoryStream(bytes);
    var a = new System.Net.Mail.Attachment(ms,
      "VIS-Termin.ics", "text/calendar");
    message.Attachments.Add(a);     
    
    // Send Mail
    SmtpClient client = new SmtpClient();
    client.Send(message);
            
