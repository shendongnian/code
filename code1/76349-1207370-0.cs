    [STAThread]
     static void Main()
        {
    
            Process[] result = Process.GetProcessesByName("ApplicationName");
            if (result.Length > 1)
            {
                MessageBox.Show("There is already a instance running.", "Information");
                System.Environment.Exit(0);
            }
            // here normal start 
        }
