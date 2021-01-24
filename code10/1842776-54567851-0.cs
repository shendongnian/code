 StringBuilder sb = new StringBuilder();
            foreach (var line in contents)
            {
                sb.AppendLine(line);
            }
            var calendarBytes = Encoding.UTF8.GetBytes(sb.ToString());
            MemoryStream memorystream = new MemoryStream(calendarBytes);
            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(memorystream, "event.ics", "text/calendar");```
