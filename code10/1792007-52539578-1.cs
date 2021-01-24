	class Temp
	{
		public int? A {get;set;}
	}
	public static void Main()
	{
		Temp obj = new Temp();
		int resultingValue = (obj.A == null  || obj.A == default(int)) ? 3 : (int) obj.A;
	}
