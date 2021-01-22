    internal class SourceData
    {
        public int TypeId { get; set; }
        public DateTime Date { get; set; }
    }
    internal class Result
    {
        public int TypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    class Program
    {
        static void Main()
        {
            var a = new List<SourceData> {
                new SourceData {TypeId = 1, Date = new DateTime(2010, 02, 01)},
                new SourceData {TypeId = 1, Date = new DateTime(2010, 02, 02)},
                new SourceData {TypeId = 1, Date = new DateTime(2010, 02, 03)}, 
                new SourceData {TypeId = 2, Date = new DateTime(2010, 02, 03)}, 
                new SourceData {TypeId = 2, Date = new DateTime(2010, 02, 04)}, 
                new SourceData {TypeId = 2, Date = new DateTime(2010, 02, 06)} 
            };
            var results = new List<Result>();
            int currentTypeId = 1;
            var rangeEndDate = new DateTime();
            DateTime rangeStartDate = a[0].Date;
            DateTime currentDate = a[0].Date;
            for (int i = 1; i < a.Count() ; i++)
            {
                if (a[i].TypeId != currentTypeId)
                {
                    results.Add(new Result() { TypeId = currentTypeId, StartDate = rangeStartDate, EndDate = rangeEndDate });
                    currentTypeId += 1;                    
                    rangeStartDate = a[i].Date;
                }
                TimeSpan tSpan = a[i].Date - currentDate;
                int differenceInDays = tSpan.Days;
                if(differenceInDays > 1)
                {
                    results.Add(new Result { TypeId = currentTypeId, StartDate = rangeStartDate, EndDate = a[i-1].Date });
                    rangeStartDate = a[i].Date;
                }
                rangeEndDate = a[i].Date;
                currentDate = a[i].Date;
            }
            results.Add(new Result { TypeId = currentTypeId, StartDate = rangeStartDate, EndDate = rangeEndDate });
            Console.WriteLine("Output\n");
            foreach (var r in results)
                Console.WriteLine( string.Format( "{0} - {1} - {2}",r.TypeId,r.StartDate.ToShortDateString(),r.EndDate.ToShortDateString()));
            Console.ReadLine();
        }
    }
