	internal static class MyClass
	{
		private delegate void ExecuteObfuscatedMethod(string value);
		private static ExecuteObfuscatedMethod Bridge; //This is my "bridge"
		internal static void CaptureExternalDelegate(object source)
		{
			//Using a "bridge" instead of the direct method name
			MethodInfo mi = typeof(MyClass).GetMethod(Bridge.Method.Name, BindingFlags.Static | BindingFlags.NonPublic);
		   
			//Less interesting code
			PropertyInfo p = source.GetType().GetProperty("SomePrivateDelegate", BindingFlags.NonPublic | BindingFlags.Instance);
			Delegate del = Delegate.CreateDelegate(p.PropertyType, mi) as Delegate;
			Delegate original = p.GetValue(source) as Delegate;
			Delegate combined = Delegate.Combine(original, del);
			p.SetValue(property, combined);
		}
		
		static MyClass()
		{
			Bridge += MyStaticMethod;
		}
		//This is the method whose name can not be retrieved by nameof () after applying ConfuserEx
		private static void MyStaticMethod(string value)
		{
			//I am testing the method's name after calling it.
			var st = new StackTrace();
			var sf = st.GetFrame(0);
			var currentMethodName = sf.GetMethod();
			throw new Exception("The method name is: " + currentMethodName); //You can see that the method has evoked and you can even see its new name
		}
	}
