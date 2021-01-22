    private void PopulateSchedulableWeeks()
    {
        int WEEKS_COUNT = 13;
        List<String> schedulableWeeks = PlatypusUtils.GetWeekBeginnings(WEEKS_COUNT).ToList();
        BindingSource bs = new BindingSource();
        bs.DataSource = schedulableWeeks;
        comboBoxWeekToSchedule.DataSource = bs;
    }
    
    public static List<String> GetWeekBeginnings(int countOfWeeks)
    {
        // from http://stackoverflow.com/questions/6346119/datetime-get-next-tuesday
        DateTime today = DateTime.Today;
        // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
        int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
        DateTime nextMonday = today.AddDays(daysUntilMonday);
    
        List<String> mondays = new List<string>();
        mondays.Add(nextMonday.ToLongDateString());
    
        for (int i = 0; i < countOfWeeks; i++)
        {
            nextMonday = nextMonday.AddDays(7);
            mondays.Add(nextMonday.ToLongDateString());
        }
        return mondays;
    }
