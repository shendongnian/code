    var DailyTime = "16:59:00";
                var timeParts = DailyTime.Split(new char[1] { ':' });
                var dateNow = DateTime.Now;
                var date = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day,
                           int.Parse(timeParts[0]), int.Parse(timeParts[1]), int.Parse(timeParts[2]));
                TimeSpan ts;
                if (date > dateNow)
                    ts = date - dateNow;
                else
                {
                    date = date.AddDays(1);
                    ts = date - dateNow;
                }
                //waits certan time and run the code
                Task.Delay(ts).ContinueWith((x) => OnTimer());
    public void OnTimer()
        {
            ViewBag.ErrorMessage = "EROOROOROROOROR";
        }
