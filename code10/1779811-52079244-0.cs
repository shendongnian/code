    private DateTime LastDate;
    private void dtPicker_ValueChanged(object sender, EventArgs e)
    {
        DateTime newDate = dtPicker.Value;
        if (newDate.Year == LastDate.Year)
        {
            if (LastDate.Month == 12 && newDate.Month == 1)
                dtPicker.Value = dtPicker.Value.AddYears(1);
            else if (LastDate.Month == 1 && newDate.Month == 12)
                dtPicker.Value = dtPicker.Value.AddYears(-1);
        }
        LastDate = dtPicker.Value;
    }
