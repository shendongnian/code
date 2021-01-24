    //AuthenticationBusiness.cs
    public string GetSecretKey()
    {
        var token = _unitOfWork.Tokens.GetToken();
        return token.SecretKey ?? string.Empty;
    }
