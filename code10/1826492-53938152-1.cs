    private bool validate(Date start, Date end, Date lunch)
    {
        return lunch < start || lunch > end;
    }
    public bool validateControl()
    {
        //executes all validations
        this.lblDay.Visible = validate(dtpStart.Value, dtpEnd.Value, dtpLunch.Value);
    }
