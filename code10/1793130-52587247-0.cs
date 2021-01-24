    class Program
    {
         static void Main(string[] args)
         {
             using (StreamWriter w = File.AppendText(@"C:\temp\log.txt"))
             {
                 Log("Test1", w);
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
