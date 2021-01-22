    		static void Main()
		{
			for (int i = 0; i < 10; i++)
			{
				bool flag = false;
				var parameterizedThread = new Thread(ParameterizedDisplayIt);
				parameterizedThread.Start(flag);
				flag = true;
			}
			Console.ReadKey();
		}
		private static void ParameterizedDisplayIt(object flag)
		{
			Console.WriteLine("Param:{0}", flag);
		}
