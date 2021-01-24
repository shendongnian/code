    public virtual async Task<IdentityResult> ConfirmEmailAsync(TUser user, string token)
    {
        // ...
        if (!await VerifyUserTokenAsync(user, Options.Tokens.EmailConfirmationTokenProvider, ConfirmEmailTokenPurpose, token))
        {
            return IdentityResult.Failed(ErrorDescriber.InvalidToken());
        }
        // ...
    }
