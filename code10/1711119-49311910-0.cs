    foreach (DataRow dr in GetQuestionSummary().Rows)
    {
        Summary summary = new Summary();
        summary.Value = dr[0].ToString().Trim();
        summary.Item = Convert.ToDouble(dr[1]);
        lstSummary.Add(summary);    
    }
