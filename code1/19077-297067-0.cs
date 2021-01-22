		public class UnitOfMeasure {
			public UnitOfMeasure(string name, int value) {
				Name = name;
				Value = value;
			}
			public string Name { get; set; }
			public int Value { get; set; }
			public static UnitOfMeasure[] All = new UnitOfMeasure[] {
				new UnitOfMeasure("Year", 356),
				new UnitOfMeasure("Month", 30),
				new UnitOfMeasure("Week", 7),
				new UnitOfMeasure("Day", 1)
			};
			public static string ConvertToDuration(int days) {
				List<string> results = new List<string>();
		
				for (int i = 0; i < All.Length; i++) {
					int count = days / All[i].Value;
					
					if (count >= 1) {
						results.Add((count + " " + All[i].Name) + (count == 1 ? string.Empty : "s"));
						days -= count * All[i].Value;
					}
				}
				return string.Join(", ", results.ToArray());
			}
		}
