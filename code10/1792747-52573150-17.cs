    public async Task TheCallerAsync()
    {
        // Grab the key from somewhere.
        string key = ...;
    
        var accountState = await <inst>.GetAccountAsync(key);
    
        //  Do something with the state.
        ...
    }
