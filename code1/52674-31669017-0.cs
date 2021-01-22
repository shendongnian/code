    private class SingleAppMutexControl : IDisposable
		{
			private readonly Mutex _mutex;
			private readonly bool _hasHandle;
			public SingleAppMutexControl(string appGuid, int waitmillisecondsTimeout = 5000)
			{
				bool createdNew;
				var allowEveryoneRule = new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
					MutexRights.FullControl, AccessControlType.Allow);
				var securitySettings = new MutexSecurity();
				securitySettings.AddAccessRule(allowEveryoneRule);
				_mutex = new Mutex(false, "Global\\" + appGuid, out createdNew, securitySettings);
				_hasHandle = false;
				try
				{
					_hasHandle = _mutex.WaitOne(waitmillisecondsTimeout, false);
					if (_hasHandle == false)
						throw new System.TimeoutException();
				}
				catch (AbandonedMutexException)
				{
					_hasHandle = true;
				}
			}
			public void Dispose()
			{
				if (_mutex != null)
				{
					if (_hasHandle)
						_mutex.ReleaseMutex();
					_mutex.Dispose();
				}
			}
		}
