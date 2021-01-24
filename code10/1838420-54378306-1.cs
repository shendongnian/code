    public class SystemFileOperations:IFileOperations
    {
    	public void Delete(string path)
    	{
    		File.Delete(path);
    	}
    }
