        // Populate combobox.
        foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
        {
            daysOfWeekCombo.Items.Add(day);
        }
        // Read combobox.
        DaysOfWeek day = (DaysOfWeek)daysOfWeekCombo.SelectedItem;
