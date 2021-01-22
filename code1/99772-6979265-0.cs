    var dtpType = typeof(DateTimePicker);
    var field = dtpType.GetField("MaxDateTime", BindingFlags.Public | BindingFlags.Static);
    if (field != null)
    {
        field.SetValue(new DateTimePicker(), DateTime.MaxValue);
    }
