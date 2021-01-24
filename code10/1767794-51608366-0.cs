		public static string ReadJson()
        {
            string json = File.ReadAllText(@"C:\Users\HP\Desktop\Output\myJson.json");
            MyClass response = JsonConvert.DeserializeObject<MyClass>(json);
			         
            return JsonConvert.SerializeObject(response, Formatting.Indented);
        }
    public class Customer
    {
        public int RATE { get; set; }
        public int FEE { get; set; }
        public int PERIOD { get; set; }
        public string NewValue
		{
			get
			{
				switch (RATE)
				{
					case 20:
						return "this is 20";
					case 40:
						return "this is 40";
					default:
						return "";
				}
			}
		}
	}
    public static void Main(string[] args)
        {
			Console.WriteLine(ReadJson());
        }
