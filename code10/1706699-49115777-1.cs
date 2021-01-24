    private void btnTest_Click(object sender, EventArgs e)
    {
        btnTest.Enabled = false;
        Task t = new Task(async () =>  { await Task.Delay(2000); EnableButton(); });
        t.Start();
    }
    private void EnableButton()
    {
        btnTest.Invoke((MethodInvoker)delegate { btnTest.Enabled = true; });
    }
