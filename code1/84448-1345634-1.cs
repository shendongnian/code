    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Decimal d = new decimal();
        d = 3.45M;
        Response.Write(d.ToDateTime().ToString());
        Response.Write("<br />");
        DateTime d2 = new DateTime(2009, 1, 1, 4, 55, 0);
        Response.Write(d2.ToDecimal().ToString());
    }
