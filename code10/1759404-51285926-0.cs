      DataTable dt = new DataTable();
      List<string> sortString = new List<string>();
      sortString.Add("open");
      sortString.Add("approved");
      sortString.Add("awaitingApproval");
    
      var listsa = dt.AsEnumerable().GroupBy(x => x["Col6"].ToString()).ToList();
      sortString.ForEach(str => listsa.ForEach(x =>
                                {
                                  if (x.Key == str)
                                    dt.Rows.Add(x.ToList());
                                }));
