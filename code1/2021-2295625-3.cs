    /// <summary>
    /// Represents a <see cref="SingleInstanceMutex"/> class.
    /// </summary>
    public partial class SingleInstanceMutex : IDisposable
    {
    	#region Fields
    
    	/// <summary>
    	/// Indicator whether another instance of this application is running or not.
    	/// </summary>
    	private bool isNoOtherInstanceRunning;
    
    	/// <summary>
    	/// The <see cref="Mutex"/> used to ask for other instances of this application.
    	/// </summary>
    	private Mutex singleInstanceMutex = null;
    
    	/// <summary>
    	/// An indicator whether this object is beeing actively disposed or not.
    	/// </summary>
    	private bool disposed;
    
    	#endregion
    
    	#region Constructor
    
    	/// <summary>
    	/// Initializes a new instance of the <see cref="SingleInstanceMutex"/> class.
    	/// </summary>
    	public SingleInstanceMutex()
    	{
    		this.singleInstanceMutex = new Mutex(true, Assembly.GetCallingAssembly().FullName, out this.isNoOtherInstanceRunning);
    	}
    
    	#endregion
    
    	#region Properties
    
    	/// <summary>
    	/// Gets an indicator whether another instance of the application is running or not.
    	/// </summary>
    	public bool IsOtherInstanceRunning
    	{
    		get
    		{
    			return !this.isNoOtherInstanceRunning;
    		}
    	}
    
    	#endregion
    
    	#region Methods
    
    	/// <summary>
    	/// Closes the <see cref="SingleInstanceMutex"/>.
    	/// </summary>
    	public void Close()
    	{
    		this.ThrowIfDisposed();
    		this.singleInstanceMutex.Close();
    	}
    
    	public void Dispose()
    	{
    		this.Dispose(true);
    		GC.SuppressFinalize(this);
    	}
    
    	private void Dispose(bool disposing)
    	{
    		if (!this.disposed)
    		{
    			/* Release unmanaged ressources */
    
    			if (disposing)
    			{
    				/* Release managed ressources */
    				this.Close();
    			}
    
    			this.disposed = true;
    		}
    	}
    	
    	/// <summary>
    	/// Throws an exception if something is tried to be done with an already disposed object.
    	/// </summary>
    	/// <remarks>
    	/// All public methods of the class must first call this.
    	/// </remarks>
    	public void ThrowIfDisposed()
    	{
    		if (this.disposed)
    		{
    			throw new ObjectDisposedException(this.GetType().Name);
    		}
    	}
    
    	#endregion
    }
