        class Program
        {
            static void Main(string[] args)
            {
                IEnumerable<AssgnData> movie2 = null;
                dataGridView1.DataSource = movie2.GroupBy(x => new {id = x.EMPLID, month = x.MNTH1})
                    .Select(x => new {
                        EMPLYID = x.Key.id,
                        MONTH = x.Key.month,
                        SUM = x.Sum(y => y.value)
                    });
                            }
        }
        public class AssgnData
        {
            public string EMPLID { get; set; }
            public string MNTH1 { get; set; }
            public int value { get;set;}
        }
