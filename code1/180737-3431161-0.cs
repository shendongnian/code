		public static void Raise<T>(this EventHandler<T> eventHandler, object sender, T e) where T : EventArgs
		{
			if (eventHandler != null)
			{
				eventHandler(sender, e);
			}
		}
