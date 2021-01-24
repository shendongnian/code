    DateTime thisDay = DateTime.Today;
    DateTime startDay;
    bool result = DateTime.TryParse(CFTestDP.SelectedDate, out startDay);//CFTestDP.SelectedDate should be string
    
    if(result)
    {
       TimeSpan dateAge = thisDay - startDay;
       txtAge.Text = string.Format("{dd}", dateAge);
    }
    else
    {
       //Unable to parse
    }
