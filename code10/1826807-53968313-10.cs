    public void someButton_Click(object sender, 
    {
        DayOfWeek whichDay = SelectADay();
        DayPanel dayPanel = _dayPanelLookup[whichDay];
        // ...
    }
