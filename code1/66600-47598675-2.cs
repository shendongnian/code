    Timer countDown= new Timer(3000);
        
    Main()
    {
        TextBox.TextDidChange += TextBox_TextDidChange;
        countdown.Elapsed += CountDown_Elapsed;
    }
    
    void TextBox_TextDidChange(Object sender, EventArgs e)
    {
        countdown.Enabled = true;
    }
    
    void CountDown_Elapsed(object sender, EventArgs e)
    {
        System.Console.WriteLine("Elapsed");
    }
