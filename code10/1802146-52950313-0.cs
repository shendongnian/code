	/// <devdoc>
	/// Searches the directory store at the given path to see whether an entry exists.
	/// </devdoc>        
	public static bool Exists(string path)
	{
		DirectoryEntry entry = new DirectoryEntry(path);
		try
		{
			entry.Bind(true);       // throws exceptions (possibly can break applications) 
			return entry.Bound;
		}
		catch (System.Runtime.InteropServices.COMException e)
		{
			if (e.ErrorCode == unchecked((int)0x80072030) ||
				 e.ErrorCode == unchecked((int)0x80070003) ||   // ERROR_DS_NO_SUCH_OBJECT and path not found (not found in strict sense)
				 e.ErrorCode == unchecked((int)0x800708AC))     // Group name could not be found
				return false;
			throw;
		}
		finally
		{
			entry.Dispose();
		}
	}
