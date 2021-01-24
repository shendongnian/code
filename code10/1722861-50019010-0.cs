    try
    {
     result = await ac.AcquireTokenSilentAsync(resource, clientId);
    }
    catch (AdalException adalException)
    {
     if (adalException.ErrorCode == AdalError.FailedToAcquireTokenSilently
         || adalException.ErrorCode == AdalError.InteractionRequired)
      {
       result = await ac.AcquireTokenAsync(resource, clientId,redirectUri,
                                           new PlatformParameters(PromptBehavior.Auto));
      }
    }
