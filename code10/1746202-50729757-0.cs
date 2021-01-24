    private async void GetIntButton(object sender, RoutedEventArgs e)
    {
        List<int> Ints = new List<int>();
        Ints.Add(await GetInt());
    }
    private async Task<int> GetInt()
    {
        await Task.Delay(100);
        return 1;
    }
