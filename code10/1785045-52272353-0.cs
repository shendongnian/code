    public async Task GetCards(CancellationTokenSource cts)
    {
        try
        {
            while (true)
            {
                CheckCardAvailability(cts);
                await Task.Delay(500, cts.Token); // or something with a timer
            }
        }
        catch (TaskCanceledException)
        {
            cts.Dispose();
        }
    }
    private /*async Task*/void CheckCardAvailability(CancellationTokenSource cts)
    {
        if (Counts.selectedCardCount == 0)
        {
            CardCountZeroMessages();
            SetMessageView(false);
            // await Task.Delay moved outside
        }
        if (XYX == 0)
        {
            // other code
            // await Task.Delay moved outside
        }
    }
