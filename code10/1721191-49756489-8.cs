    private static void BeginInvoke(DispatcherPriority prio, Action action)
		{
			try
			{
				if (Application.Current != null)
				{
					if (Application.Current.Dispatcher.CheckAccess())
						action();
					else
						Application.Current.Dispatcher.BeginInvoke(prio, (ThreadStart)(() => action()));
				}
			}
			catch (Exception err)
			{
				BusinessLogger.Manage(err);
			}
		}
