    private void btnTest_Click(object sender, EventArgs e)
    {
        btnTest.Enabled = false;
        Task t = new Task(() => { System.Threading.Thread.Sleep(2000); EnableButton(); });
        t.Start();
    }
    private void EnableButton()
    {
        btnTest.BeginInvoke((MethodInvoker)delegate { btnTest.Enabled = true; });
    }
