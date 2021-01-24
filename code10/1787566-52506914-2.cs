    if(activity.Value != null)
    {
        DateTimeInp input = JsonConvert.DeserializeObject<DateTimeInp>(activity.Value.ToString());
        var toDateTime = input.ToDateTime();
        if(toDateTime != null)
        {
            activity.Text = toDateTime.ToString();
        }
    }
