    class Program
	{
          static object locker = new object();
          static EventWaitHandle clearCount 
              =new EventWaitHandle(false, EventResetMode.ManualReset);
	  static void Main(string[] args)
	  {
	    for (int j = 0; j < 100; j++)
	    {
	       ThreadPool.QueueUserWorkItem(dostuff, j);
	    }
	    clearCount.WaitOne();
	  }
	  static void dostuff(dynamic input)
	  {
	    lock (locker)
	    {
	      Console.WriteLine(input);
              if (input == 99) clearCount.Set();
	     }
	   }
	}
