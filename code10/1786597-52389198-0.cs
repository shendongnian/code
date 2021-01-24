    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //here we create our 3 forms.  note, you can create and show as many as you want here
            //the application will automatically loop through them
            new Form1().Show();
            new Form2().Show();
            new Form().Show();
            //minimize all forms, and set a close handler
            foreach (Form form in Application.OpenForms)
            {
                form.WindowState = FormWindowState.Minimized;
                form.FormClosed += Form_FormClosed;
            }
            //start a thread to manage switching them
            Task.Run((Action)Go);
            //start the main UI thread loop
            Application.Run();
        }
        private static void Go()
        {
            while (true)
            {
                //loop through all forms
                foreach (Form form in Application.OpenForms)
                {
                    //show it (send execution to UI thread)
                    form.Invoke(new MethodInvoker(() =>
                    {
                        form.Show();
                        form.WindowState = FormWindowState.Maximized;
                    }));
                    //wait 5 seconds
                    Thread.Sleep(5000);
                    //minimize it (send execution to UI thread)
                    form.Invoke(new MethodInvoker(() =>
                    {
                        form.WindowState = FormWindowState.Minimized;
                    }));
                }
            }
        }
        private static void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
