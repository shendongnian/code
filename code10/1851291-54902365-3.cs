    private async void button2_Click(object sender, EventArgs e)
    {
        Debug.WriteLine("Before LongOperationAsync");
     
        int result = await LongOperationAsync();
     
        Debug.WriteLine("After LongOperationAsync");
        Debug.WriteLine("Result: {0}", result);
    }
