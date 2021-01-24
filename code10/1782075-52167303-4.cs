    private async Task MyMethodAsync()
    {
        await Task.Delay(2000);
        message = "Finished";      // The execution of this line will be delayed by 2 seconds.
    }
    private void button2_Click(object sender, EventArgs e)
    {
        message = "Started";
        MyMethodAsync();           // Since this method is not awaited,
        MessageBox.Show(message);  // the execution of this line will NOT be delayed.
    }
