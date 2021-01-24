    private async Task OnAuthorizationCodeReceived(AuthorizationCodeReceivedNotification notification)
    {
        // Extract the code from the response notification
        var code = notification.Code;
        string signedInUserID = notification.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;
