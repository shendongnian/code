	using System;
	using System.Threading;
	using System.Windows;
	using System.Windows.Threading;
	namespace Sheva.Windows
	{
		/// <summary>
		/// Designates a Windows Presentation Foundation application with added functionalities.
		/// </summary>
		public class WpfApplication : Application
		{
			/// <summary>
			/// Processes all messages currently in the message queue.
			/// </summary>
			/// <remarks>
			/// This method can potentially cause code re-entrancy problem, so use it with great care.
			/// </remarks>
			public static void DoEvents()
			{
				Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));
			}
		}
	}
