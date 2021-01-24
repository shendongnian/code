    private async void button1_Click(object sender, EventArgs e)
    {
        await Task.Delay(2000);
        message = "Finished";      // The execution of this line will be delayed by 2 seconds.
    }
    private void button2_Click(object sender, EventArgs e)
    {
        message = "Started";
        button1_Click(null, null); // Since this "method" is not awaited,
        MessageBox.Show(message);  // the execution of this line will NOT be delayed.
    }
