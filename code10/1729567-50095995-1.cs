    var week = dt.AsEnumerable().GroupBy(row => Convert.ToDateTime(row["Date"]))
                  .Select(g => new
                  {
                      Date = ComputeMaturity(g.Key, DateTime.Now),
                  }).ToList();
    dataGridView1.DataSource = week;
