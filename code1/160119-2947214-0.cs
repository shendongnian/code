    private void SearchTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
    if (SearchTextBoxTimer != null)
    {
       Console.WriteLine("The user is currently typing.");
       if (SearchTextBoxTimer.Interval < 750)
       {
           SearchTextBoxTimer.Interval += 750;
           Console.WriteLine("Delaying...");
       }
    }
    else
    {
        Console.WriteLine("The user just started typing.");
        SearchTextBoxTimer = new System.Windows.Forms.Timer();
        SearchTextBoxTimer.Tick += new EventHandler(SearchTextBoxTimer_Tick);
        SearchTextBoxTimer.Interval = 500;
        SearchTextBoxTimer.Start();
    }
    }
