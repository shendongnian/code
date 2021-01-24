    private void validate(DateTimePicker start, DateTimePicker end, DateTimePicker lunch, Label day)
    {
        if ((lunch.Value < start.Value || lunch.Value >= end.Value))
        {
            day.Visible = true;
        }
        if ((lunch.Value >= start.Value && lunch.Value < end.Value))
        {
            day.Visible = false;
        }
    }
