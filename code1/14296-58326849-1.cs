    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security.AccessControl;
    using System.Security.Principal;
    using System.Threading;
    
    namespace HQ.Util.General.Threading
    {
    	public class MutexGlobal : IDisposable
    	{
    		// ************************************************************************
    		public string Name { get; private set; }
    		internal Mutex Mutex { get; private set; }
    		public int DefaultTimeOut { get; set; }
    		public Func<int, bool> FuncTimeOutRetry { get; set; }
    
    		// ************************************************************************
    		public static MutexGlobal GetApplicationMutex(int defaultTimeOut = Timeout.Infinite)
    		{
    			return new MutexGlobal(defaultTimeOut, ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value);
    		}
    
    		// ************************************************************************
    		public MutexGlobal(int defaultTimeOut = Timeout.Infinite, string specificName = null)
    		{
    			try
    			{
    				if (string.IsNullOrEmpty(specificName))
    				{
    					Name = Guid.NewGuid().ToString();
    				}
    				else
    				{
    					Name = specificName;
    				}
    
    				Name = string.Format("Global\\{{{0}}}", Name);
    
    				DefaultTimeOut = defaultTimeOut;
    
    				FuncTimeOutRetry = DefaultFuncTimeOutRetry;
    
    				var allowEveryoneRule = new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), MutexRights.FullControl, AccessControlType.Allow);
    				var securitySettings = new MutexSecurity();
    				securitySettings.AddAccessRule(allowEveryoneRule);
    
    				Mutex = new Mutex(false, Name, out bool createdNew, securitySettings);
    
    				if (Mutex == null)
    				{
    					throw new Exception($"Unable to create mutex: {Name}");
    				}
    			}
    			catch (Exception ex)
    			{
    				Log.Log.Instance.AddEntry(Log.LogType.LogException, $"Unable to create Mutex: {Name}", ex);
    				throw;
    			}
    		}
    
    		// ************************************************************************
    		/// <summary>
    		/// 
    		/// </summary>
    		/// <param name="timeOut"></param>
    		/// <returns></returns>
    		public MutexGlobalAwaiter GetAwaiter(int timeOut)
    		{
    			return new MutexGlobalAwaiter(this, timeOut);
    		}
    
    		// ************************************************************************
    		/// <summary>
    		/// 
    		/// </summary>
    		/// <param name="timeOut"></param>
    		/// <returns></returns>
    		public MutexGlobalAwaiter GetAwaiter()
    		{
    			return new MutexGlobalAwaiter(this, DefaultTimeOut);
    		}
    
    		// ************************************************************************
    		/// <summary>
    		/// This method could either throw any user specific exception or return 
    		/// true to retry. Otherwise, retruning false will let the thread continue
    		/// and you should verify the state of MutexGlobalAwaiter.HasTimedOut to 
    		/// take proper action depending on timeout or not. 
    		/// </summary>
    		/// <param name="timeOutUsed"></param>
    		/// <returns></returns>
    		private bool DefaultFuncTimeOutRetry(int timeOutUsed)
    		{
    			// throw new TimeoutException($"Mutex {Name} timed out {timeOutUsed}.");
    
    			Log.Log.Instance.AddEntry(Log.LogType.LogWarning, $"Mutex {Name} timeout: {timeOutUsed}.");
    			return true; // retry
    		}
    
    		// ************************************************************************
    		public void Dispose()
    		{
    			if (Mutex != null)
    			{
    				Mutex.ReleaseMutex();
    				Mutex.Close();
    			}
    		}
    
    		// ************************************************************************
    
    	}
    }
