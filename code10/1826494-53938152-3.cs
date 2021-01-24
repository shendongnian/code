    private bool validate(DateTime start, DateTime end, DateTime lunch)
    {
        return lunch < start || lunch > end;
    }
    public bool validateControl()
    {
        //executes all validations
        this.lblDay.Visible = validate(dtpStart.Value, dtpEnd.Value, dtpLunch.Value);
    }
