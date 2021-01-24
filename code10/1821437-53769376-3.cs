    public async Task<IActionResult> Callback([FromServices] IUserRepository userRepository)
    {
        ...
        // lookup our user and external provider info
        var (user, provider, providerUserId, claims) = FindUserFromExternalProvider(result);
        if (user == null)
        {
            // We don't have a local user.
            return RedirectToAction("SomeAction", "SomeController");
        }
        ...
    }
