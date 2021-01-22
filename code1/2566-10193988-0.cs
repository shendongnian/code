    public class DirectoryFileCounter
    {
        int mDirectoriesToRead = 0;
    	// Pass this method the parent directory path
    	public void ADirectoryPathWasSelected(string path)
    	{
    		// create a task to do this in the background for responsive ui
            // state is the path
    		Task.Factory.StartNew((state) =>
    		{
    			try
    			{
    				// Get the first layer of sub directories
    				this.AddCountFilesAndFolders(state.ToString())
    				
    				
    			 }
    			 catch // Add Handlers for exceptions
    			 {}
    		}, path));
    	}
    	
    	// This method is called recursively
    	private void AddCountFilesAndFolders(string path)
    	{
    		try
    		{
    			// Only doing the top directory to prevent an exception from stopping the entire recursion
    			var directories = Directory.EnumerateDirectories(path, "*.*", SearchOption.TopDirectoryOnly);
    			
    			// calling class is tracking the count of directories
    			this.mDirectoriesToRead += directories.Count();
    			
    			// get the child directories
    			// this uses an extension method to the IEnumerable<V> interface,
               // which will run a function on an object. In this case 'd' is the 
               // collection of directories
    			directories.ActionOnEnumerable(d => AddCountFilesAndFolders(d));
    		}
    		catch // Add Handlers for exceptions
    		{
    		}
    		try
    		{
    			// count the files in the directory
    			this.mFilesToRead += Directory.EnumerateFiles(path).Count();
    		}
    		catch// Add Handlers for exceptions
    		{ }
    	}
    }
    // Extension class
    public static class Extensions
    { 
    	// this runs the supplied method on each object in the supplied enumerable
    	public static void ActionOnEnumerable<V>(this IEnumerable<V> nodes,Action<V> doit)
    	{
    
    		foreach (var node in nodes)
    		{	
    			doit(node);
    		}
    	}
    }
