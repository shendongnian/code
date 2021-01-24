    var week = dt.AsEnumerable().GroupBy(row => ComputeMaturity(Convert.ToDateTime(row["Date"]),DateTime.Now))
                  .Select(g => new
                  {
                      Date = (g.Key),
                  }).ToList();
    dataGridView1.DataSource = week;
