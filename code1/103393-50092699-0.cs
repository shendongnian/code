    public static void ThreadAwareRaise<TEventArgs>(this EventHandler<TEventArgs> customEvent,
		object sender, TEventArgs e) where TEventArgs : EventArgs
	{
		foreach (var d in customEvent.GetInvocationList().OfType<EventHandler<TEventArgs>>())
			switch (d.Target)
			{
				case DispatcherObject dispatchTartget:
					dispatchTartget.Dispatcher.BeginInvoke(d, sender, e);
					break;
				case ISynchronizeInvoke syncTarget:
					if(syncTarget.InvokeRequired)
						syncTarget.BeginInvoke(d, new[] {sender, e});
					else
						goto default;
					break;
				default:
					d.Invoke(sender, e);
					break;
			}
	}
