    HttpContext httpContext = HttpContext.Current;
    string authHeader = httpContext.Request.Headers["Authorization"];
    if (authHeader == null || !authHeader.StartsWith("Basic"))
        throw new Exception("The authorization header is empty or isn't Basic.");
    string encodedCredentials = authHeader.Substring("Basic".Length).Trim();
    string credentialPair = Encoding.Unicode.GetString(Convert.FromBase64String(encodedCredentials));
    var credentials = credentialPair.Split(new[] { ":" }, StringSplitOptions.None);
    var username = credentials[0];
    var password = credentials[1];
