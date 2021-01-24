    public async void Button_Click(object sender, RoutedEventArgs e)
    {
       try
       {
          MessageBox.Show(await GetAMessage());
       }
       catch (Exception exception)
       {
          // log the nelly out of it
          // or display message
       }
    
    }
    
    public async Task<string> GetAMessage()
    {
       var list = await GetLinesAsync();
    
       return string.Join("\n", list);
    }
    
    public List<string> ExpensiveFunction()
    {
       // ...
       return new List<string>();
    }
    
    
    public async Task<List<string>> GetLinesAsync()
    {
       var result = Task.Run(() => ExpensiveFunction());
       return await result;
    }
