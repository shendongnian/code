    using System.IO;
    
    class Program
    {
        static void Main()
        {
    	// 1: Write single line to new file
    	using (StreamWriter writer = new StreamWriter("C:\\log.txt", true))
    	{
    	    writer.WriteLine("Important data line 1");
    	}
    	// 2: Append line to the file
    	using (StreamWriter writer = new StreamWriter("C:\\log.txt", true))
    	{
    	    writer.WriteLine("Line 2");
    	}
        }
    }
    
    Output
        (File "log.txt" contains these lines.)
    
    Important data line 1
    Line 2
