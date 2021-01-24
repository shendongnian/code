    public DateTime CurrentTime
    {
        get => DateTime.Now;
    }
    
    public CurrentViewModelTime(object sender, RoutedEventArgs e)
    {
        _ = Update(); // calling an async function we do not want to await
    }
    
    private async Task Update()
    {
        while (true)
        {
            await Task.Delay(100);
            OnPropertyChanged(nameof(CurrentTime)));
        }
    }
