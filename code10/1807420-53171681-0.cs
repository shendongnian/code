    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        using (var monitor = new WinFormMonitor())
        {
            monitor.NewFormCreated += (sender, form) => { MessageBox.Show($"hi {form.Text}"); };
            Application.Run(new Form1());
        }
    }
