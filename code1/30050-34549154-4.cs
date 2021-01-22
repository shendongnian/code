	using System;
	using System.Linq;
	using System.Runtime.InteropServices;
	using System.Threading;
	namespace YourNamespace
	{
		class Program
		{
			// if you want to allow only one instace otherwise remove the next line
			static Mutex mutex = new Mutex(false, "YOURGUID-YOURGUID-YOURGUID-YO");
			static ManualResetEvent run = new ManualResetEvent(true);
			
			[DllImport("Kernel32")]
			private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);                
			private delegate bool EventHandler(CtrlType sig);
			static EventHandler exitHandler;
			enum CtrlType
			{
				CTRL_C_EVENT = 0,
				CTRL_BREAK_EVENT = 1,
				CTRL_CLOSE_EVENT = 2,
				CTRL_LOGOFF_EVENT = 5,
				CTRL_SHUTDOWN_EVENT = 6
			}
			private static bool ExitHandler(CtrlType sig)
			{
				Console.WriteLine("Shutting down: " + sig.ToString());            
				run.Reset();
				Thread.Sleep(2000);
				return false; // If the function handles the control signal, it should return TRUE. If it returns FALSE, the next handler function in the list of handlers for this process is used (from MSDN).
			}
			
			static void Main(string[] args)
			{
				// if you want to allow only one instace otherwise remove the next 4 lines
				if (!mutex.WaitOne(TimeSpan.FromSeconds(2), false))
				{
					return; // singleton application already started
				}
				exitHandler += new EventHandler(ExitHandler);
				SetConsoleCtrlHandler(exitHandler, true);
				try
				{
					Console.BackgroundColor = ConsoleColor.Gray;
					Console.ForegroundColor = ConsoleColor.Black;
					Console.Clear();
					Console.SetBufferSize(Console.BufferWidth, 1024);
					
					Console.Title = "Your Console Title - XYZ";
					
					// start your threads here
					Thread thread1 = new Thread(new ThreadStart(ThreadFunc1));
					thread1.Start();
					
					Thread thread2 = new Thread(new ThreadStart(ThreadFunc2));
					thread2.IsBackground = true; // a background thread
					thread2.Start();
					
					while (run.WaitOne(0))
					{
						Thread.Sleep(100);
					}
								 
					// do thread syncs here signal them the end so they can clean up or use the manual reset event in them or abort them
					thread1.Abort();
				}
				catch (Exception ex)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("fail: ");
					Console.ForegroundColor = ConsoleColor.Black;
					Console.WriteLine(ex.Message);
					if (ex.InnerException != null)
					{
						Console.WriteLine("Inner: " + ex.InnerException.Message);
					}
				}
				finally
				{                
					// do app cleanup here
				
					// if you want to allow only one instace otherwise remove the next line
					mutex.ReleaseMutex();
					
					// remove this after testing
					Console.Beep(5000, 100);
				}
			}
			public static void ThreadFunc1()
			{
				Console.Write("> ");
				while ((line = Console.ReadLine()) != null)
				{
					if (line == "command 1")
					{
					
					}
					else if (line == "command 1")
					{
					
					}
					else if (line == "?")
					{
					
					}
					
					Console.Write("> ");
				}
			}
			public static void ThreadFunc2()
			{
				while (run.WaitOne(0))
				{
					Thread.Sleep(100);
				}
                                
               // do thread cleanup here
				Console.Beep();			
			}
		}
	}
