    [STAThread]
    static void Main()
    {
        using (Form form = new Form())
        using (Timer tmr = new Timer())
        {
            tmr.Interval = 500;
            bool first = true;
            tmr.Tick += delegate
            {
                tmr.Stop();
                form.Opacity = 1;
            };
            form.Move += delegate
            {
                if (first) { first = false; return; }
                tmr.Stop();
                tmr.Start();
                form.Opacity = 0.3;
            };
            Application.Run(form);
        }
    }
