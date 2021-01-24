    CronValues cv = new CronValues();
    // GET: Scheduler
    [HttpGet]
    public ActionResult schedulerIndex()
    {
        var dayOfMonthList = new List<CronValues>
        {
            new CronValues{DayOfMonth = Convert.ToInt32(Enumerable.Range(1,31).ToList()),IsChecked = false}
        };
        var dayOfWeekList = new List<CronValues>
        {
            new CronValues{DayOfWeek = Convert.ToInt32(Enum.GetValues(typeof(CronValues.DaysOfWeek))),IsChecked = false}
        };
        var monthList = new List<CronValues>
        {
            new CronValues{DayOfMonth = Convert.ToInt32(Enum.GetValues(typeof(CronValues.Months))),IsChecked = false}
        };
        return View(new IndexSchedulerViewModel
        {
            DayOfMonthList = dayOfMonthList,
            DayOfWeekList = dayOfWeekList,
            MonthList = monthList
        });
    }
