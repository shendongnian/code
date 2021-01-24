	public static Task<tResult> onGuiThread<tResult>( Func<tResult> func )
	{
		var disp = Application.Current.Dispatcher;
		if( disp.CheckAccess() )
			return Task.FromResult( func() );
		TaskCompletionSource<tResult> tcs = new TaskCompletionSource<tResult>();
		Action act = () =>
		{
			try
			{
				tcs.SetResult( func() );
			}
			catch( Exception ex )
			{
				tcs.SetException( ex );
			}
		};
		Application.Current.Dispatcher.BeginInvoke( act );
		return tcs.Task;
	}
