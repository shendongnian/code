    namespace ConsoleApplication1
    {
        public class Program
        {
            static void Main()
            {
                Process process = new Process();
    
                // Configure the process using the StartInfo properties.
                process.StartInfo.FileName = @"C:\Users\tugadoje\Documents\Visual Studio 2013\Projects\ConsoleApplication2\ConsoleApplication2\bin\Debug\ConsoleApplication2.exe";
                process.StartInfo.Arguments = "\"I am passing this argument \n my newline\"";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                process.Start();
                process.WaitForExit();// Waits here for the process to exit.
    
                Console.Read();
            }
        }
    }
