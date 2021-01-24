    for (int i = 1; i < dt.Rows.Count; i++) // start from 1
    {
        myrow = dt.Rows[i];
        //if (i == 0)
        //{
        //    myrow = dt.Rows[i +1];
        //}
        for (int j = 1; j < dt.Columns.Count; j++)
        {
            try
            {
                // CHANGES MADE HERE ---------------------------------------vvvvvvvvvvvvv--------------------------vvvvvvvv
                str.Append("insert into HousingLoanInsuranceRate values ("+ dt.Rows[0][j] + "," + myrow[0] + "," + myrow[j] + ",0,0)");
                str.Append("<br/>");
            }
            catch (Exception ex)
            {
            }
        }
    }
