	class Program
	{
		static void Main(string[] args)
		{
			EventWaitHandle handle = 
				new EventWaitHandle(true, EventResetMode.ManualReset, "GoodMutexName");
			handle.Set();
		}
	}
