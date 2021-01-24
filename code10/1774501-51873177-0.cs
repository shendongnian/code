    private async void button_Click(object sender, EventArgs e)
    {
        ThirdParty.Stuff newStuff = new ThirdParty.Stuff();
    
        //call some functions...
    
        var tcs = new TaskCompletionSource<int>();
        int mode;
        newStuff.SetConfig += (_id, _mode, ex) =>
        {
           if(!string.IsNullOrWhitespace(ex))
           {
              tcs.TrySetException(new Exception(ex));
           }
           else
           {
              mode = _mode;
              tcs.TrySetResult(_id);
           }
        }
        newStuff.SetConfig(5, 10);
        //call other functions...
        var id = await tcs.Task;
        Console.WriteLine("ID is " + id + " and this.Mode is " + mode);
    }
