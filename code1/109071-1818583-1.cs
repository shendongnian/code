    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        foreach (string line in textBox1.Lines)
        {  
            Dig digger = new Dig(line, textBox1.Text);
            digger.DomainChecked += new Dig.DomainCheckedHandler(OnUpdateTicker);
            string response = digger.GetAllInfo();
            richTextBox1.Invoke((Action) delegate { richTextBox1.AppendText(response); });
        }
    }
