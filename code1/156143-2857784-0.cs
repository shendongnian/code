    DateTime date;
    if (DateTime.TryParse(dateString, out date))
    {
       date = date.Date; // Get's the date-only component.
       // Do something cool.
    }
    else
    {
       // Flip out because you didn't get a real date.
    }
