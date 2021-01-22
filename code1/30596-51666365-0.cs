    if (SKYLib.AccountsPayable.Client.ApiAuthorization.Authorization.AccessTokenExpiry == null || SKYLib.AccountsPayable.Client.ApiAuthorization.Authorization.AccessTokenExpiry < DateTime.Now)
    {
        SKYLib.AccountsPayable.Client.ApiAuthorization.Authorization.Refresh();
        _api = new SKYLib.AccountsPayable.Api.DefaultApi(new SKYLib.AccountsPayable.Client.Configuration { DefaultHeader = SKYLib.AccountsPayable.Client.ApiAuthorization.Authorization.ApiHeader });
    }
