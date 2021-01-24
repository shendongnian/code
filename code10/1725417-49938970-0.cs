    private async void button1_Click(object sender, EventArgs e)
    {
        // this function must be async because if awaits
        // it is an event hander, hence it returns void instead of Task
        try
        {
            Method1();
            // call TestAsync, if you do not need the result right now,
            // do not await yet
            var myTask = TestAsync();
        
            // as soon as TestAsync has to await, it continues here:
            // results from TestAsync are not available yet
            DoSomeOtherProcessing();
            // now you need the result from testAsync; await the Task
            bool result = await myTask;
            ProcessResult(result);
        }
        catch (Exception)
        {
           ...
        }
    }
