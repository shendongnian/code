    private async void button2_Click(object sender, EventArgs e)
    {
        Debug.WriteLine("Before LongOperationAsync");
        Task<int> task = LongOperationAsync();
        var result = await task;
        Debug.WriteLine("After LongOperationAsync");
        Debug.WriteLine("Result: {0}", result);
    }
