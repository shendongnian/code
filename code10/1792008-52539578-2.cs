	class Temp
	{
		public int? A {get;set;}
	}
	public static void Main()
	{
		Temp obj = new Temp();
		int resultingValue1 = (obj.A == null  || obj.A == default(int)) ? 3 : (int) obj.A;
        // or
        int resultingValue2 = obj.A.IsNullEmpty() ? 3 : (int) obj.A;
	}
