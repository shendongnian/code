	class Program
	{
		public static void Main(string[] args)
		{
			var typeCounter = new TypeCounter();
			using (StreamWriter vehicleWriter = new StreamWriter(@"C:\Users\Admin\Desktop\Program\vehicles2.txt"))
			using (StreamReader vehicleReader = new StreamReader(@"C:\Users\Admin\Desktop\Program\vehicles.txt"))
			{
				string line;
				while ((line = vehicleReader.ReadLine()) != null)
				{
					var parts = line.Split(',');
					string type = parts[0].Substring(0, 4); // not sure why you're using substring, I'm just matching what you did
					var identifier = typeCounter.GetIdentifier(type);
					vehicleWriter.WriteLine($"{identifier},{line}");
				}
			}
			Console.ReadKey();
		}
	}
	public class TypeCounter
	{
		private IDictionary<string, int> _typeCount = new Dictionary<string, int>();
		public string GetIdentifier(string type)
		{
			int number;
			if (_typeCount.ContainsKey(type))
			{
				number = ++_typeCount[type];
			}
			else
			{
				number = 1;
				_typeCount.Add(type, number);
			}
			return $"{type}{number:00}"; // feel free to use more zeros
		}
	}
