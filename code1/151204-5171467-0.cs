        /// <summary>
    	/// Detects the moment when environment is about to be shutdown.
    	/// <remarks>
    	///		For usage just create single instance of it.
    	///		Each time when GC calles Finilize a '~ShutdownDetector' will be called.
    	/// </remarks>
    	/// </summary>
    	public sealed class ShutdownDetector
    	{
    		/// <summary>
    		/// Initializes a new instance of the <see cref="T:ShutdownDetector"/> class.
    		/// </summary>
    		/// <param name="notifier">The notifier</param>
    		public ShutdownDetector(Notifier notifier)
    		{
    			if (notifier == null) throw new ArgumentNullException("notifier");
    			_notifier = notifier;
    		}
    
    		/// <summary>
    		/// Releases unmanaged resources and performs other cleanup operations before the
    		/// <see cref="T:CQG.PDTools.Common.ShutdownDetector"/> is reclaimed by garbage collection.
    		/// </summary>
    		~ShutdownDetector()
    		{
    			if (Environment.HasShutdownStarted)
    			{
    				onShutdown();
    			}
    			else
    			{
    				new ShutdownDetector(_notifier);
    			}
    		}
    
    		/// <summary>
    		/// Called when component needs to signal about shutdown.
    		/// </summary>
    		private void onShutdown()
    		{
    			if (_notifier != null)
    			{
    				_notifier();
    			}
    		}
    
    		Notifier _notifier;
    		public delegate void Notifier();
    	}
