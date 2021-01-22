    protected void rangeVal(object sender, ServerValidateEventArgs e)
    {
        DateTime dateCheck = txtDate1.Text.Trim();
        DateTime select;
        if (DateTime.TryParse(dateCheck, out select))
        {
            e.IsValid = IsDateTimeValidForMyApplication(select);
        }
        else
            e.IsValid = false;
    }
    bool IsDateTimeValidForMyApplication(DateTime dt)
    {
        return dt.Year > 2000;   //or whatever business rules your app has...
    }
