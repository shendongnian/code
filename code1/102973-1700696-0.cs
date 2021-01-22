    class Program
	{
		static void Main(string[] args)
		{
			Console.ReadLine();
			for(int i=0;i<10;i++)
			{
				AppDomain appDomain = AppDomain.CreateDomain("MyTemp");
				appDomain.DoCallBack(loadAssembly);
				appDomain.DomainUnload += appDomain_DomainUnload;
				AppDomain.Unload(appDomain);		
			}
			AppDomain appDomain2 = AppDomain.CreateDomain("MyTemp2");
			appDomain2.DoCallBack(loadAssembly);
			appDomain2.DomainUnload += appDomain_DomainUnload;
			
			AppDomain.Unload(appDomain2);
			GC.Collect();
			GC.WaitForPendingFinalizers();	
			Console.ReadLine();
		}
		private static void loadAssembly()
		{
			string fullPath = @"E:\tmp\sandbox\AppDomains\AppDomains1\AppDomains1\bin\Debug\BigLib.dll";
			var assembly = Assembly.LoadFrom(fullPath);
			var instance = Activator.CreateInstance(assembly.GetTypes()[0]);
			Console.WriteLine("Creating instance of {0}", instance.GetType());
			Thread.Sleep(2000);
			instance = null;
		}
		private static void appDomain_DomainUnload(object sender, EventArgs e)
		{
			AppDomain ap = sender as AppDomain;
			Console.WriteLine("Unloading {0} AppDomain", ap.FriendlyName);
		}
	}
