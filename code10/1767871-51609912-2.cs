    public void M() {
        
        var t = DoWork(1);
        
    }
    
    public async Task DoWork(int amount)
    {
        if(amount == 1)
            throw new ArgumentException();
        
        await Task.Delay(1);
    }
