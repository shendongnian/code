    class Program
        {
            static void Main(string[] args)
            {
                var masterData = new List<Data>
                {
                    new Data{ id = 1, t_id =1, value = 10, comment="test1", date=Convert.ToDateTime("01-01-2018") },
                    new Data{ id = 2, t_id =1, value = 10, comment="test2", date=Convert.ToDateTime("01-01-2018") },
                    new Data{ id = 3, t_id =1, value = 10, comment="test3", date=Convert.ToDateTime("01-01-2018") },
                    new Data{ id = 4, t_id =2, value = 10, comment=null, date=Convert.ToDateTime("01-02-2018") },
                    new Data{ id = 5, t_id =2, value = 10, comment="test5", date=Convert.ToDateTime("01-03-2018") },
                };
    
                var chartResults = new List<ChartResult>();
    
                foreach (var date in masterData.Select(i => i.date).Distinct().ToList())
                {
                    var commentsForDate = masterData.Where(i => i.date == date).Select(i => i.comment).ToList();
                    var maxValue = masterData.Where(i => i.date == date).Max(i => i.value);
                    chartResults.Add(new ChartResult
                    {
                        Comments = commentsForDate,
                        X = date,
                        Y = maxValue
                    });
                }
            }
        }
    
        public class ChartResult
        {
            public DateTime X { get; set; }
            public double Y { get; set; }
            public List<string> Comments { get; set; }
        }
    
    
        public class Data
        {
            public int id { get; set; }
            public int t_id { get; set; }
            public int value { get; set; }
            public string comment { get; set; }
            public DateTime date { get; set; }
        }
