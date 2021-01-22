    message.Body = null;
    using (AlternateView body =
    AlternateView.CreateAlternateViewFromString(
        "Some Message Body",
        message.BodyEncoding,
        message.IsBodyHtml ? "text/html" : null))
    {
    body.TransferEncoding = 
        TransferEncoding.SevenBit;
    message.AlternateViews.Add(body);
    }
