    private async void button1_Click(object sender, EventArgs e)
    {
        // Call the method that runs asynchronously.
        string result = await WaitAsynchronouslyAsync();
        // Display the result.
        textBox1.Text += result;
    }
    //The following method runs asynchronously.The UI thread is not
    //blocked during the delay.You can move or resize the Form1 window 
    //while Task.Delay is running.
    public async Task<string> WaitAsynchronouslyAsync()
    {
        await dvm.SetVoltage(5, rigNo); //Task.Delay(10000);
        return "Finished";
    }
