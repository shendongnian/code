    public string get()    // For option 2 say public async Task<string> get() 
    {
        //Option 1 - Using Task<string>
        Task<string> cnt = module.a<string>(x, file()); // or var cnt = ...
        MessageBox.Show(cnt.GetAwaiter().GetResult()); // Return the string you want
        //Option 2 - Using await
        MessageBox.Show(await module.a<string>(x, file())); // Return the string you want
    }
