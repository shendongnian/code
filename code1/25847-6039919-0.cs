    public IEnumerable<IResult> HandleButtonClick() {
        yield return Show.Busy();
        
        var loginCall = new LoginResult(wsClient, Username, Password);
        yield return loginCall;
        this.IsLoggedIn = loginCall.Success;
        
        yield return Show.NotBusy();
    }
