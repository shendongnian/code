    public string get()    //or add async for option 2
    {
        //Option 1 - Using Task<string>
        Task<string> cnt = module.a<string>(x, file()); // or var cnt = ...
        MessageBox.Show(cnt.GetAwaiter().GetResult()); // Return the string you want
        //Option 2 - Using await
        MessageBox.Show(await module.a<string>(x, file())); // Return the string you want
    }
