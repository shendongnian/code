    class Program
    {
        static void Main(string[] args)
        {
            Process myProcess = new System.Diagnostics.Process(); 
            myProcess.StartInfo.FileName = @"rundll32.exe"; 
            myProcess.EnableRaisingEvents = true;
            myProcess.StartInfo.Arguments = @"C:\winnt\System32\shimgvw.dll,ImageView_Fullscreen c:\leaf.jpg";
            myProcess.Exited += new System.EventHandler(Process_OnExit); 
            myProcess.Start();
            Console.Read();
            
        }
        public static void Process_OnExit(object sender, EventArgs e)
        {
            Console.WriteLine("called");
            Console.Read();
        } 
    }
 
