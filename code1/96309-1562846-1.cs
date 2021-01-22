    public class IntWrapper{
		public IntWrapper(int v) { Value = v; }
		public int Value { get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			var kvp = new KeyValuePair<string, int>("1",1);
			kvp.Value = 17;
			var dictionary = new Dictionary<string, IntWrapper>()
            {
                {"1", new IntWrapper(1)}, {"2", new IntWrapper(2)}, {"3", new IntWrapper(3)}
            };
			foreach (var s in dictionary.Keys)
			{
				dictionary[s].Value = 1;  //OK
				dictionary[s] = new IntWrapper(1); // boom
			}
		} 
