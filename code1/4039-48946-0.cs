    private void Form1_Load(object sender, EventArgs e)
    {
        Hide();
        bool done = false;
        ThreadPool.QueueUserWorkItem((x) =>
        {
            using (var splashForm = new SplashForm())
            {
                splashForm.Show();
                while (!done)
                    Application.DoEvents();
                splashForm.Close();
            }
        });
        Thread.Sleep(3000); // Emulate hardwork
        done = true;
        Show();
    }
