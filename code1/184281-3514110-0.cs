    List<DateTime> dates = new List<DateTime>();
    foreach (DataRow rowMonth in myDS.Tables[0].Rows)
    {
        DateTime rowDate = DateTime.Parse(rowMonth[0]);
        dates.Add(rowDate);
    }
