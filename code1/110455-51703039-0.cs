	DateTime startDate = DateTime.Parse("2018-06-24 06:00");
			DateTime endDate = DateTime.Parse("2018-06-24 11:45");
			while (startDate.AddMinutes(15) <= endDate)
			{
				
				Console.WriteLine(startDate.ToString("yyyy-MM-dd HH:mm"));
				startDate = startDate.AddMinutes(15);
			}
