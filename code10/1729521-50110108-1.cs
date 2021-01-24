        public interface ISeriesData
        {
            DateTime CreatedTime { get; }
        }
        public class StringData : ISeriesData
        {
            public StringData(string name)
            {
                this.Name = name;
                this.CreatedTime = DateTime.Now;
            }
            public string Name { get; }
            public DateTime CreatedTime { get; }
        }
        public class IntegerData : ISeriesData
        {
            public IntegerData(int value)
            {
                this.Value = value;
                this.CreatedTime = DateTime.Now;
            }
            public DateTime CreatedTime { get; }
            public int Value { get; }
        }
        public class SeriesDto
        {
            public List<ISeriesData> Data { get; set; }
            // Other options ...
        }
        public class HighchartsDto
        {
            // Lot of things..
            // ...
            public List<SeriesDto> Series { get; set; } // doesn't compile
        }
        class Program
        {
            static void Main(string[] args)
            {
                var a = new StringData("A");
                var b = new IntegerData(1001);
                var dto = new SeriesDto();
                dto.Data.Add(a);
                dto.Data.Add(b);
                var list = new HighchartsDto();
                list.Series.Add(dto);
                DateTime time = list.Series[0].Data[0].CreatedTime; // time
            }
        }
