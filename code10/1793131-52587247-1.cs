    class Program
    {
         static void Main(string[] args)
         {
             bool WriteDone = false;
             while(!WriteDone)
             {
                 try 
                 {
                     using (StreamWriter w = File.AppendText(@"C:\temp\log.txt"))
                     {
                        Log("Test1", w);
                     }
                     WriteDone = true;
                  } 
                  catch 
                  { 
                       System.Threading.Thread.Sleep(1000); // Wait for 1s and try again
                  }
             }
             Console.ReadLine();
         }
         
         public static void Log(string logMessage, TextWriter w)
         {
             w.WriteLine(DateTime.Now.ToShortDateString() + " | " + DateTime.Now.ToLongTimeString());
             w.WriteLine(logMessage);
             w.WriteLine("-----------------------------------------------------------------------");
         }
     }
