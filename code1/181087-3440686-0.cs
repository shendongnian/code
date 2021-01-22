    var days = new List<string>();
    foreach (CheckBox chk in gpbSchedule.Controls.OfType<CheckBox>())
    {
        if (chk.Checked)
        {
            days.Add(chk.Text);
        }
    }
    string daysString = "";
    if (days.Count == 1)
    {
        daysString = days[0];
    }
    else if (days.Count > 1)
    {
        daysString =
            string.Join(", ", days.Take(days.Count - 1)) +
            " and " +
            days[days.Count - 1];
    }
