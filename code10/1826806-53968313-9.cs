    private static readonly TimeSpan DefaultTime = TimeSpan.Zero;
    private void Form1_Load(object sender, EventArgs e)
    {
        SetDefaults();
    }
    private void SetDefaults()
    {
        foreach (DayPanel dayPanel in _dayPanelLookup.Values)
        {
            dayPanel.Start = DefaultTime;
            dayPanel.Lunch = DefaultTime;
            dayPanel.End = DefaultTime;
        }
    }
