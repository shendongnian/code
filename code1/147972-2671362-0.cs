    // Add your own DateTimes
    DateTime[] times = new[] { new DateTime(2010, 4, 20, 16, 30,0,0), new DateTime(2010, 4, 20, 17, 0,0,0) };
    Timer t = new Timer();
    t.Interval = 30000; // 30 seconds, feel free to change
    // Each 30 secs check to see if the _time_ is before one of the ones specified; if it is RunMethod()
    t.Tick += (sender, e) => { if (times.Any(d => { DateTime dt = DateTime.Now; new DateTime(dt.Year, dt.Month, dt.Day, d.Hour, d.Minute, d.Second, d.MilleSecond).CompareTo(DateTime.Now) <= 0)) RunMethod(); }
