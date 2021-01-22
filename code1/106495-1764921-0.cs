    private void AddValue(StringBuilder time, int units, string unitLabel)
    {
        if (units > 0)
        {
            if (0 < time.Length)
            {
                time.Append(" and ");
            }
            time.AppendFormat("{0} {1}{2}", units, unitLabel, (1 == units ? String.Empty : "s"));
        }
    }
    private void YourExistingMethod()
    {
        StringBuilder time = new StringBuilder();
        AddValue(time, Settings.Default.WaitPeriod.Hours, "hour");
        AddValue(time, Settings.Default.WaitPeriod.Minutes, "minute");
        AddValue(time, Settings.Default.WaitPeriod.Seconds, "second");
        this.questionLabel.Text = String.Format("What have you been doing for the past {0}?", time);
    }
