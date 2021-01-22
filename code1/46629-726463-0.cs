    public void EnumInstanceFromString()
    {
    
     DayOfWeek wednesday = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), "Wednesday");
     DayOfWeek sunday = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), "sunday", true);
     DayOfWeek tgif = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), "FRIDAY", true);
     lblOutput.Text = wednesday.ToString() +
                      ".  Int value = " + 
                      (int)wednesday).ToString() + "<br>";
     lblOutput.Text += sunday.ToString() + 
                       ".  Int value = " + 
                       ((int)sunday).ToString() + "<br>";
     lblOutput.Text += tgif.ToString() + 
                       ".  Int value = " + 
                       ((int)tgif).ToString() + "<br>";
     }
