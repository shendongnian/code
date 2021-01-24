        static void Main(string[] args)
        {
            //Main App Process.
            if (args.Length == 0)
            {
                //Saves current process info to pass on command line.
                main = Process.GetCurrentProcess();
                mainProcessID = main.Id;
                //Initializes the helper process
                checker = new Process();
                checker.StartInfo.FileName = main.MainModule.FileName;
                checker.StartInfo.Arguments = mainProcessID.ToString();
                checker.EnableRaisingEvents = true;
                checker.Exited += new EventHandler(checker_Exited);
                //Launch the helper process.
                checker.Start();
                Application.Run(new MainForm()); // your winform app
            }
            else //On the helper Process
            {
                main = Process.GetProcessById(int.Parse(args[0]));
                main.EnableRaisingEvents = true;
                main.Exited += new EventHandler(main_Exited);
                while (!main.HasExited)
                {
                    Thread.Sleep(1000); //Wait 1 second. 
                }
                //Provide some time to process the main_Exited event. 
                Thread.Sleep(2000);
            }
        }
        //Double checks the user not closing the checker process.
        static void checker_Exited(object sender, EventArgs e)
        {           
            //This only checks for the task manager process running. 
            //It does not make sure that the app has been closed by it. But close enough.
            //If you can think of a better way please let me know.
            if (Process.GetProcessesByName("taskmgr").Length != 0)
            {
                MessageBox.Show("Task Manager killed helper process.");
                //If you like you could kill the main app here to. 
                //main.Kill();
            }
        }
        //Only gets to run on the checker process. The other one should be dead. 
        static void main_Exited(object sender, EventArgs e)
        {
            //This only checks for the task manager process running. 
            //It does not make sure that the app has been closed by it. But close enough.
            //If you can think of a better way please let me know.
            if (Process.GetProcessesByName("taskmgr").Length != 0)
            {
                MessageBox.Show("Task Manager killed my application.");
            }
        }
    }
