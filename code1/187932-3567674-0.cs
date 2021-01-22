    public delegate void UpdateTextBox(string data);
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        ...
        Invoke(new UpdateTextBox(textBoxData), data);
        ...
    
    }
    
    private void textBoxData(string data)
    {
                textBox1.Text += data;
    }
