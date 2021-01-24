    private async void button1_Click(object sender, EventArgs e)
    {
        try
        {
            await Task.WhenAll(DoLongThingAsyncEx1(), DoLongThingAsyncEx2());
        }
        catch (Exception ex)
        {
            Debugger.Break();
        }
    }
    
    Task DoLongThingAsyncEx1()
    {
        return Task.Run(() =>
        {
            Task.Delay(1000).Wait();
            throw new InvalidTimeZoneException();
        });
    }
    
    Task DoLongThingAsyncEx2()
    {
        return Task.Run(() =>
        {
            Task.Delay(10000).Wait();
            throw new ArgumentException();
        });
    }
