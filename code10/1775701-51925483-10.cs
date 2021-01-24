    protected void Test_Click(object sender, EventArgs e)
    {
        List<int> weekNumbers = GetWeeksInYear(2018);    
    
        DateTime firstDayOfWeek = FirstDateOfWeek(2018, weekNumbers.ElementAt(3), CultureInfo.CurrentCulture);
        DateTime lastDayOfWeek = LastDayOfWeek(firstDayOfWeek);    
    
        for (var date = firstDayOfWeek; date.Date <= lastDayOfWeek; date = date.AddDays(1))
        {
            //Your rest of code is same here
        }
    }
