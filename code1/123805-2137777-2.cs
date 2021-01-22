    protected void Button1_Click(object sender, System.EventArgs e)
    {
        DateTime TimeIn = (System.DateTime)ddlTimeInHour.Text + ":" + ddlTimeInMinute.Text;
        if (ddlTimeInAMPM.Text == "PM") {
            TimeIn = DateAdd(DateInterval.Hour, 12, TimeIn);
        }
        
        DateTime TimeOut = (System.DateTime)ddlTimeOutHour.Text + ":" + ddlTimeOutMinute.Text;
        if (ddlTimeOutAMPM.Text == "PM") {
            TimeOut = DateAdd(DateInterval.Hour, 12, TimeOut);
        }
        
        int DiffMins = DateDiff(DateInterval.Minute, TimeIn, TimeOut);
        Response.Write("The difference is " + DiffMins + " mins");
    }
