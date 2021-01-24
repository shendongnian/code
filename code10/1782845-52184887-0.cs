        class Program
        {
            static void Main(string[] args)
            {
                List<File> files = new List<File>() {
                    new File() { FileName = "DBTestScripts/SQLParallel/Insert_50000_Sales", CreatedByDate = DateTime.Parse("2018-08-07 12:12:12")},
                    new File() { FileName = "DBTestScripts/SQLParallel/Insert_50000_Sales", CreatedByDate = DateTime.Parse("2018-08-09 12:12:12")}
                };
                var results = files.GroupBy(x => x.FileName).Select(x => x.OrderByDescending(y => y.CreatedByDate).FirstOrDefault()).ToList();
            }
        }
        public class File
        {
            public string FileName { get;set;}
            public DateTime CreatedByDate { get;set;}
        }
