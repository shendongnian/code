    protected void btnCommit(object sender, EventArgs e) => new PayrollContext().InsertPayroll(new SqlParameter() 
    {
         Name = "Hours",
         SqlDbType = SqlDbType.Decimal,
         Value = txtHours.Text
    }
