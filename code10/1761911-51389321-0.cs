    public Task<TokenDto> GenerateAuthToken(TokenRequestDto dto)
    {
        switch (dto.GrantType)
        {
            case "password":
                // asynchronous, return the task
                return GetToken(dto.ClientId, dto.Email, dto.Password); 
            case "refresh_token":
                // synchronous, use a completed task
                return Task.FromResult(GetRefreshToken(dto.RefreshToken));
            default:
                // don't return null, throw instead
                throw new ArgumentOutOfRangeException(nameof(dto.GrantType));
        }
    }
