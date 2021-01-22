    DateTime date1 = DateTime.Now;
    System.Threading.Thread.Sleep(2500);
    DateTime date2 = DateTime.Now;
    TimeSpan elapsed = date2.Subtract(date1);
    
    string[] Split = elapsed.ToString().Split('.');
    string m = Split[0]; // Returns 00:00:02
