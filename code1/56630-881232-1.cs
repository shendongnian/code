    private void HardWork(object state)
    {
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(500);
            SetText(i.ToString());
        }
    }
    
    private void SetText(string text)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new Action<string>(SetText), text);
        }
        else
        {
            textBox1.Text = text;
        }
    }
    private void Button_Click(object sender, EventArgs e)
    {
        ThreadPool.QueueUserWorkItem(HardWork);            
    }
