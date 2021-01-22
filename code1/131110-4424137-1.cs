    protected void Form1_load(object sender, EventArgs e)
    {
        Signal.OnSignal += new EventHandler(IGotSignal)
    }
    
    protected void IGotSignal(object sender, EventArgs e)
    {
        MessageBox.Show("i got a signal")
    }
    
    protected void button1_Click(object sender,EventArgs e)
    {
        Signal.SendSignal();
    }
