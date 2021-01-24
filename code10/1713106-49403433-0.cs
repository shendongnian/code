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
        return Task.Run(async () =>
        {
            await Task.Delay(1000);
            throw new InvalidTimeZoneException();
        });
    }
    
    Task DoLongThingAsyncEx2()
    {
        return Task.Run(async () =>
        {
            await Task.Delay(10000);
            throw new ArgumentException();
        });
    }
