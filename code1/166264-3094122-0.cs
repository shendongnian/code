    DateTime result;
    if (DateTime.TryParse(txtStartDate.Text, out result))
    {
       cmdSearch.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime));
       cmdSearch.Parameters["@StartDate"].Value = result;
    }
