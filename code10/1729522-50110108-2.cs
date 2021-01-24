        public class SeriesDto<T> 
        {
            public List<T> Data { get; set; }
            // Other options ...
        }
        public class HighChartsDto<L, T>  where L : SeriesDto<T>
        {
            // Lot of things..
            // ...
            public int SomethingElse { get; set; }
            public List<L> Series { get; set; } // doesn't compile
        }
        public class HighChartsStringDto : HighChartsDto< SeriesDto<string>, string>
        {
        }
        class Program
        {
            static void Main(string[] args)
            {
                var a = new SeriesDto<string>();
                a.Data.Add("A");
                a.Data.Add("B");
                a.Data.Add("C");
                var b = new SeriesDto<string>();
                b.Data.Add("1");
                b.Data.Add("2");
                b.Data.Add("3");
           
                var list = new HighChartsStringDto();
                list.Series.Add(a);
                list.Series.Add(b);
                string x = list.Series[1].Data[2];  // "C"
            }
        }
