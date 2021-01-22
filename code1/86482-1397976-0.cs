    /// <summary>
    /// Encapsulates the SVNLook command in all of it's flavours
    /// </summary>
    public static class SvnLookCommand
    {
    	/// <summary>
    	/// The string &quot;&quot; used as parameter for the svnlook.exe
    	/// </summary>
    	private static readonly string AUTHOR = "author";
    
    	/// <summary>
    	/// The string &quot;cat&quot; used as parameter for the svnlook.exe
    	/// </summary>
    	private static readonly string CAT = "cat";
    
    	/// <summary>
    	/// The string &quot;changed&quot; used as parameter for the svnlook.exe
    	/// </summary>
    	private static readonly string CHANGED = "changed";
    
    	/// <summary>
    	/// The string &quot;date&quot; used as parameter for the svnlook.exe
    	/// </summary>
    	private static readonly string DATE = "date";
    
    	/// <summary>
    	/// The string &quot;diff&quot; used as parameter for the svnlook.exe
    	/// </summary>
    	private static readonly string DIFF = "diff";
    
    	/// <summary>
    	/// The string &quot;dirs-changed&quot; used as parameter for the svnlook.exe
    	/// </summary>
    	private static readonly string DIRSCHANGED = "dirs-changed";
    
    	/// <summary>
    	/// The string &quot;history&quot; used as parameter for the svnlook.exe
    	/// </summary>
    	private static readonly string HISTORY = "history";
    
    	/// <summary>
    	/// The string &quot;info&quot; used as parameter for the svnlook.exe
    	/// </summary>
    	private static readonly string INFO = "info";
    
    	/// <summary>
    	/// The string &quot;lock&quot; used as parameter for the svnlook.exe
    	/// </summary>
    	private static readonly string LOCK = "lock";
    
    	/// <summary>
    	/// The string &quot;log&quot; used as parameter for the svnlook.exe
    	/// </summary>
    	private static readonly string LOG = "log";
    
    	/// <summary>
    	/// The string &quot;tree&quot; used as parameter for the svnlook.exe
    	/// </summary>
    	private static readonly string TREE = "tree";
    
    	/// <summary>
    	/// The string &quot;uuid&quot; used as parameter for the svnlook.exe
    	/// </summary>
    	private static readonly string UUID = "uuid";
    
    	/// <summary>
    	/// The string &quot;youngest&quot; used as parameter for the svnlook.exe
    	/// </summary>
    	private static readonly string YOUNGEST = "youngest";
    
    	/// <summary>
    	/// The full path of the svnlook.exe binary
    	/// </summary>
    	private static string commandPath = String.Empty;
    
    	/// <summary>
    	/// Initializes static members of the <see cref="SvnLookCommand"/> class.
    	/// </summary>
    	static SvnLookCommand()
    	{
    		commandPath = Settings.Default.SvnDirectoryPath;
    
    		if (!Path.IsPathRooted(commandPath))
    		{
    			Assembly entryAssembly = Assembly.GetEntryAssembly();
    			if (entryAssembly != null)
    			{
    				commandPath = new FileInfo(entryAssembly.Location).Directory.ToString() + Path.DirectorySeparatorChar + commandPath;
    			}
    		}
    
    		if (!commandPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
    		{
    			commandPath = commandPath + Path.DirectorySeparatorChar;
    		}
    
    		commandPath += "svnlook.exe";
    	}
    
    	/// <summary>
    	/// Gets the process info to start a svnlook.exe command with parameter &quot;author&quot;
    	/// </summary>
    	/// <param name="repository">The repository.</param>
    	/// <param name="revision">The revision.</param>
    	/// <returns>Gets the author of the revision in scope</returns>
    	public static ProcessStartInfo GetAuthor(string repository, string revision)
    	{
    		ProcessStartInfo svnLookProcessStartInfo = new ProcessStartInfo(commandPath);
    		svnLookProcessStartInfo.Arguments = String.Format("{0} {1} -r {2}", AUTHOR, repository, revision);
    		return svnLookProcessStartInfo;
    	}
    
    	/// <summary>
    	/// Gets the process info to start a svnlook.exe command with parameter &quot;log&quot;
    	/// </summary>
    	/// <param name="repository">The repository.</param>
    	/// <param name="revision">The revision.</param>
    	/// <returns>The svn log of the revision in scope</returns>
    	public static ProcessStartInfo GetLog(string repository, string revision)
    	{
    		ProcessStartInfo svnLookProcessStartInfo = new ProcessStartInfo(commandPath);
    		svnLookProcessStartInfo.Arguments = String.Format("{0} {1} -r {2}", LOG, repository, revision);
    		return svnLookProcessStartInfo;
    	}
    
    	/// <summary>
    	/// Gets the process info to start a svnlook.exe command with parameter &quot;changed&quot;
    	/// </summary>
    	/// <param name="repository">The repository.</param>
    	/// <param name="revision">The revision.</param>
    	/// <returns>The change log of the revision in scope</returns>
    	public static ProcessStartInfo GetChangeLog(string repository, string revision)
    	{
    		ProcessStartInfo svnLookProcessStartInfo = new ProcessStartInfo(commandPath);
    		svnLookProcessStartInfo.Arguments = String.Format("{0} {1} -r {2}", CHANGED, repository, revision);
    		return svnLookProcessStartInfo;
    	}
    
    	/// <summary>
    	/// Gets the process info to start a svnlook.exe command with parameter &quot;info&quot;
    	/// </summary>
    	/// <param name="repository">The repository.</param>
    	/// <param name="revision">The revision.</param>
    	/// <returns>The info of the revision in scope</returns>
    	public static ProcessStartInfo GetInfo(string repository, string revision)
    	{
    		ProcessStartInfo svnLookProcessStartInfo = new ProcessStartInfo(commandPath);
    		svnLookProcessStartInfo.Arguments = String.Format("{0} {1} -r {2}", INFO, repository, revision);
    		return svnLookProcessStartInfo;
    	}
    }
