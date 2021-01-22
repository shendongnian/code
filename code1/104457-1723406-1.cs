    string tz = userList.Rows[0][1].ToString().Trim();
    //Timezones can take the form of + or - followed by hour and then minutes in 15 minute increments.
    Match tzre = new Regex(@"^(\+|-)?(0?[0-9]|1[0-2])(00|15|30|45)$").Match(tz);
    if (!tzre.Success)
    {
        throw new
            myException("Row 1, column 2 of the CSV file to be imported must be a valid timezone: " + tz);
    }
    GroupCollection tzg = tzre.Groups;
    tz = (new TimeSpan(int.Parse(tzg[1].Value + tzg[2].Value), int.Parse(tzg[3].Value), 0).TotalMinutes).ToString();
