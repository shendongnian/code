        public static void Main()
        {
            Process myProcess = new Process();
            try
            {                
                myProcess.StartInfo.UseShellExecute = true;
                // You can start any process, HelloWorld is a do-nothing example.
                myProcess.StartInfo.FileName = "X.exe"; /
                myProcess.WorkingDirectory = "C:\SomeDirectory That contains A and A.tmp"
                myProcess.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
