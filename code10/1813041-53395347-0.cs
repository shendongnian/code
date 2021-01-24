    string[] splitTime = man_hours_nbr.Text.Split(':');
    int hours = Int32.Parse(splitTime[0]);
    int minutes = Int32.Parse(splitTime[1]);
    int seconds = Int32.Parse(splitTime[2]);
    double totalHours = hours + minutes / 60.0 + seconds / 3600.0;
