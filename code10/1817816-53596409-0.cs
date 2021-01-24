    public static class CurrentTest
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
    // start test
    CurrentTest.StartTime = DateTime.Now;
    CurrentTest.EndTime = CurrentTest.StartTime.AddMinutes(15);  // 15 minutes for test
    // inside timer loop on your forms
    if (CurrentTest.EndTime <= DateTime.Now)
    { 
        // test is over
    } else {
        timeleftLabel.Text = (CurrentTest.EndTime - DateTime.Now).ToString();
    }
    
