    foreach (GridViewRow row in gridEmployee.Rows) 
    {
        if(row.RowType == DataControlRowType.DataRow)
        {
            DataRow dr = dt.NewRow();
            dr["EmpId"] = Convert.ToInt64(row.Cells[0].Text);
            dr["FromDate"] = Convert.ToDateTime(GetMonthNumberFromAbbreviation(fromdate[1].ToString()) + '/' + fromdate[0].ToString() + '/' + fromdate[2].ToString());
            dr["ToDate"] = Convert.ToDateTime(GetMonthNumberFromAbbreviation(todate[1].ToString()) + '/' + todate[0].ToString() + '/' + todate[2].ToString());
            dr["DaysPresent"] = Convert.ToDecimal(row.Cells[4].Text);
            dr["OpeningAdvance"] = Convert.ToDouble(row.Cells[5].Text);
            dr["AdvanceDeducted"] = Convert.ToDouble(row.Cells[6].Text);
            dr["RemainingAdvance"] = Convert.ToDouble(row.Cells[7].Text);
            dr["SalaryGiven"] = Convert.ToDouble(row.Cells[8].Text);
            dr["CreatedDate"] = Convert.ToDateTime(System.DateTime.Now.ToString());
            dt.Rows.Add(dr);
        }
    }  
 
