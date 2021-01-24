    foreach (Attendee item in context.Attendees.Include(attendee => attendee.Tags))
    {
        int column = 1;
        worksheet.Cells[counter, column++].Value = item.Id;
        worksheet.Cells[counter, column++].Value = item.FirstName;
        worksheet.Cells[counter++, column++].Value = item.LastName;
    }
