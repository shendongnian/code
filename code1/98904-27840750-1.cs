    public void date()
    {
        Datetime startdate;
        Datetime enddate;
        Timespan remaindate;
        startdate = DateTime.Parse(txtstartdate.Text).Date;
        enddate = DateTime.Parse(txtenddate.Text).Date;
        remaindate = enddate - startdate;
        if (remaindate != null)
        {
            lblmsg.Text = "you have left with " + remaindate.TotalDays + "days.";
        }
        else
        {
            lblmsg.Text = "correct your code again.";
        }
    }
    protected void btncal_Click(object sender, EventArgs e)
    {
        date();
    }
