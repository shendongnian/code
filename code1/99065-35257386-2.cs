        int WEEKS_TO_OFFER_COUNT = 13;
        BindingSource bs = new BindingSource();
        Dictionary<String, DateTime> schedulableWeeks = AYttFMConstsAndUtils.GetWeekBeginningsDict(WEEKS_TO_OFFER_COUNT);             bs.DataSource = schedulableWeeks;
        comboBoxWeekToSchedule.DataSource = bs;
        comboBoxWeekToSchedule.DisplayMember = "Key";
        comboBoxWeekToSchedule.ValueMember = "Value";
    
    public static Dictionary<String, DateTime> GetWeekBeginningsDict(int countOfWeeks)
    {
        DateTime today = DateTime.Today;
        // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
        int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
        DateTime nextMonday = today.AddDays(daysUntilMonday);
    
        Dictionary<String, DateTime> mondays = new Dictionary<String, DateTime>();
        mondays.Add(nextMonday.ToLongDateString(), nextMonday);
    
        for (int i = 0; i < countOfWeeks; i++)
        {
            nextMonday = nextMonday.AddDays(7);
            mondays.Add(nextMonday.ToLongDateString(), nextMonday);
        }
        return mondays;
    }
