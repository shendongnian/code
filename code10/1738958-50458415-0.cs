	public class Program
	{
		//Returns a string indicating the format of the input, or null if could not be detected
		public static string GetDateTimeFormatCode(string dateTimeString)
		{
			//Parse the input
			DateTime dateTime;
			if (!DateTime.TryParse(dateTimeString, out dateTime)) return null;
			return
			(
				new string[]
				{
					"M/d/yyyy",
					"d MMM yyyy",
					"d MMMM yyyy",
					"dddd MMMM d yyyy"
				}
			)
			.Where( c => dateTime.ToString(c) == dateTimeString )
			.FirstOrDefault();
		}
		
		public static void Main()
		{
			var tests = new List<string>
			{
				@"21 May 2018",
				@"6/21/2018",
				@"Monday May 21 2018"
			};
			
			foreach (var t in tests)
			{
				Console.WriteLine("Input '{0}' uses format '{1}'", t, GetDateTimeFormatCode(t) ?? "?");
			}
								  
		}
	}
