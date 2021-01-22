    public IEnumerable<Report> ToReportList(DataTable dt)
    {
      return dt.AsEnumerable().Select(dr => new Report
                                            {
                                                member1 = dr["column1"].ToString(),
                                                ...
                                            });
    }
