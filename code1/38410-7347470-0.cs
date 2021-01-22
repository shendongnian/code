	public static void WaitForConnectionEx(this NamedPipeServerStream stream)
	{
		var evt = new AutoResetEvent(false);
		Exception e = null;
		stream.BeginWaitForConnection(ar => 
		{
			try
			{
				stream.EndWaitForConnection(ar);
			}
			catch (Exception er)
			{
				e = er;
			}
			evt.Set();
		}, null);
		evt.WaitOne();
		if (e != null)
			throw e; // rethrow exception
	}
