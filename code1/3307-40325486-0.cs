	public class Person{
	
		public string FullName  => $"{First} {Last}"; // expression body notation
		
		public string First { get; set; } = "First";
		public string Last { get; set; } = "Last";
	}
