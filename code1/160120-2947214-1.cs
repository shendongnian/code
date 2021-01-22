    private void SearchTextBoxTimer_Tick(object sender, EventArgs e)
    {
        Console.WriteLine("The user finished typing.");
        if (SearchTextBox.Text == "")
        {
            ConsoleTextBox.Text = "Searching: All";
        }
        else
        {
            ConsoleTextBox.Text = "Searching: " + SearchTextBox.Text;
        }
        SearchTextBox_TextChanged();
        SearchTextBoxTimer.Stop();
        SearchTextBoxTimer.Dispose();
        SearchTextBoxTimer = null;
    }
