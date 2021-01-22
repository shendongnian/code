    private void btnShowProgress_Click(object sender, EventArgs e)
    {
        progressBar1.Value = 0;
    
        Task.Run(() =>
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(100);
                progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Value = i; }));                    
            }
        });
    }
