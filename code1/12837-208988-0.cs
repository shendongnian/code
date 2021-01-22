		public static void foo(Type t, params object[] p)
		{
			System.Diagnostics.Debug.WriteLine("<---- foo");
			foreach(System.Reflection.ConstructorInfo ci in t.GetConstructors())
			{
				System.Diagnostics.Debug.WriteLine(t.FullName + ci.ToString());
			}
			foreach (object o in p)
			{
				System.Diagnostics.Debug.WriteLine("param:" + o.GetType().FullName);
			}
			System.Diagnostics.Debug.WriteLine("foo ---->");
		}
    // ...
    foo(designerAttribute.Designer, new DelayComposite(4));
    var designer = Activator.CreateInstance(designerAttribute.Designer, new DelayComposite(4));
    
