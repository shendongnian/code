	void Main()
	{
		bool condition = true;	
		var a = 1;
		var b = 2;
		var c = 3;
		SomeKindaHelper.TernaryAssign<int>(condition, ref a, ref b, c);
		Console.WriteLine($"a = {a}; b = {b}; c = {c}");	
	}
	public static class SomeKindaHelper
	{
		public static void TernaryAssign<T>(bool condition, ref T assignToMeIfConditionIsTrue, ref T assignToMeIfConditionIsFalse, T newValue)
		{
			if (condition)
			{
				assignToMeIfConditionIsTrue = newValue;
			}
			else 
			{
				assignToMeIfConditionIsFalse = newValue;
			}
		}
	}
	
