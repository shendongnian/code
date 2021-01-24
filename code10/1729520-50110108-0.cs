		public class SeriesDto
		{
			public ArrayList Data { get; set; }
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
				var dto = new SeriesDto();
				dto.Data.Add("A string");
				dto.Data.Add(1001);
				dto.Data.Add(new TimeSpan(0, 0, 15));
				var list = new HighchartsDto();
				list.Series.Add(dto);
				TimeSpan time = (TimeSpan)list.Series[0].Data[2]; // 15 seconds
			}
		}
