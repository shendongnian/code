    DateTime yesterdaydate = DateTime.Now.AddDays(-1);
    string year = yesterdaydate.Year.ToString();
    string month = yesterdaydate.Month.ToString();
    string day = yesterdaydate.Day.ToString();
    string path = Path.Combine("C:\\Users\\ales\\Desktop\\test", year, month, day);
   
