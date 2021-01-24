	void Main()
	{
		MethodInfo targetMethod = typeof(TargetObj).GetProperty("Count").GetSetMethod();
		MethodInfo injectMethod = typeof(InjectObj).GetMethod("SetCount");
		
		targetMethod.InjectMethod(injectMethod);
		
		var targetInstance = new TargetObj();
		
		targetInstance.Count = 3;
	}
	
	public class TargetObj
	{
	    public int Count { get; set; }
	}
	
	public class InjectObj
	{
		public void SetCount(int value)
		{
			GetBackingField(this, "Count").SetValue(this, value);
			Console.WriteLine($"Count has been set to [{value}]");
		}
	}
	
	public static FieldInfo GetBackingField(object obj, string propertyName) => obj.GetType().GetField($"<{propertyName}>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);
