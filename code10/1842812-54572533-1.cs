    // Save the information in the cookie
    var info = await mvcContext.HttpContext.AuthenticateAsync("Cookies");
    info.Properties.UpdateTokenValue("refresh_token", newRefreshToken);
    info.Properties.UpdateTokenValue("access_token", newAccessToken);
    info.Properties.UpdateTokenValue("expires_at", expiresAt.ToString("o", CultureInfo.InvariantCulture));
    await mvcContext.HttpContext.SignInAsync("Cookies", info.Principal, info.Properties);
