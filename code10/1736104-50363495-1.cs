		public class Result
		{
			// This constructor is used by the "different separator for Earned and Possible" approach.
			// Remove this and the default constructor if you don't want to go that way.
			public Result(string line)
			{
				var parts = line.Split(',');
				if (parts.Length != 2)
				{
					throw new ArgumentException($"Result had {parts.Length} parts: '{line}'");
				}
				EarnedPoints = int.Parse(parts[0]);
				PossiblePoints = int.Parse(parts[1]);
			}
			public Result()
			{
			}
			// Remove this constructor if you go for the approach above.
			public Result(int earnedPoints, int possiblePoints)
			{
				EarnedPoints = earnedPoints;
				PossiblePoints = possiblePoints;
			}
			public int EarnedPoints { get; }
			public int PossiblePoints { get; }
			public double Grade => (double)EarnedPoints / PossiblePoints;
			public string GradeAsPercentage => $"{Grade:P2}";
		}
		public class Student
		{
			public Student(string line)
			{
				var parts = line.Split(new[] { "||" }, StringSplitOptions.None);
				// Could use this instead if you go for TSV:   var parts = line.Split('\t');
				if (parts.Length != 4)
				{
					throw new ArgumentException($"Student had {parts.Length} parts: '{line}'");
				}
				Id = parts[0];
				Forenames = parts[1];
				Surname = parts[2];
				string remainder = parts[3];
				// This is how simple it would be if you used a different separator to group the Earned and Possible together
				//        Results = remainder.Split(';').Select(result => new Result(result)).ToList();
				// Below is an approach where commas are used for everything...
				Results = new List<Result>();
				var items = remainder.Split(',');
				if (items.Length % 2 == 1)
				{
					throw new ArgumentException($"Odd number of parts in the result: '{line}'");
				}
				int offset = 0;
				while (offset < items.Length)
				{
					int earnedPoints = int.Parse(items[offset++]);
					int possiblePoints = int.Parse(items[offset++]);
					Results.Add(new Result(earnedPoints, possiblePoints));
				}
			}
			public string Id { get; } // Could make this an 'int', in which case use "int.Parse(parts[0])" when setting it, above
			public string Forenames { get; }
			public string Surname { get; }
			public IList<Result> Results { get; }
			public double AverageGrade => Results.Average(r => r.Grade);
			public string AverageGradeAsPercentage => $"{AverageGrade:P2}";
		}
