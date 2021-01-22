		static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			try
			{
				String CurrentThreadName = System.Threading.Thread.CurrentThread.Name;
				if (e.IsTerminating)
					Logger.Log("Program", 0, String.Format("Received fatal unhandled exception on '{0}' thread.  Exception will follow.", CurrentThreadName), MsgCategory.Critical, 50);
				else
					Logger.Log("Program", 0, String.Format("Received unhandled exception on '{0}' thread.  Exception will follow.", CurrentThreadName), MsgCategory.Error, 25);
				if (e.ExceptionObject != null)
					Logger.LogException("Program", String.Format("Unhandled System Exception on '{0}' thread.", CurrentThreadName), 50, (Exception)e.ExceptionObject);
			}
			catch
			{
			}
			if (e.IsTerminating)
			{
				Exception ThisException = (Exception)e.ExceptionObject;
				String CurrentThreadName = System.Threading.Thread.CurrentThread.Name;
				MessageBox.Show(
						String.Format(Localization.GetString("fatal_error"), ThisException.GetType().ToString(), ThisException.Message, ThisException.StackTrace, CurrentThreadName)
						, Localization.GetString("dialogtitle")
						, MessageBoxButtons.OK
						, MessageBoxIcon.Error
						, MessageBoxDefaultButton.Button1);
			}
		}
