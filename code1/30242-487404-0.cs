    static void Main(string[] args)
    {
    	using (FileStream fs = File.OpenRead(@"D:\temp\case\mytest.txt"))
    	{
    		StringBuilder path = new StringBuilder(512);
    		GetFinalPathNameByHandle(fs.SafeFileHandle.DangerousGetHandle(), path, path.Capacity, 0);
    		Console.WriteLine(path.ToString());
    	}
    }
    
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern int GetFinalPathNameByHandle(IntPtr handle, [In, Out] StringBuilder path, int bufLen, int flags);
