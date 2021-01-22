    using System;
    using System.Reflection;
    namespace TestAppDomain
    {
	class Program
	{
		static void Main(string[] args)
		{
			AppDomain pluginsAppDomain = AppDomain.CreateDomain("Plugins");
			Foo foo = new Foo();
			pluginsAppDomain.SetData("Foo", foo);
			Bar bar= (Bar) pluginsAppDomain.CreateInstanceAndUnwrap(Assembly.GetEntryAssembly().FullName, typeof (Bar).FullName);
			bar.UseIt();
			AppDomain.Unload(pluginsAppDomain);
			foo.SaySomething();
		}
	}
	class Bar : MarshalByRefObject
	{
		public void UseIt()
		{
			Console.WriteLine("Current AppDomain: {0}", AppDomain.CurrentDomain.FriendlyName);
			Foo foo = (Foo) AppDomain.CurrentDomain.GetData("Foo");
			foo.SaySomething();
		}
	}
	class Foo : MarshalByRefObject
	{
		public void SaySomething()
		{
			Console.WriteLine("Something from AppDomain: {0}", AppDomain.CurrentDomain.FriendlyName);
		}
	}
    }
