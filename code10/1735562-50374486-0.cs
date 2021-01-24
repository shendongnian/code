    public void SendEmail(MicroserviceMailMessage email)
    {
        var url = _azureEndpoint;
        var transformedEmail = TransformEmail(email);
        var content = new CapturedMultipartContent();
        content.AddJson("email", transformedEmail);
        foreach (var attachment in email.Attachments)
        {
            var inline = attachment.ContentDisposition.Inline ? "inline." : "";
            content.AddFile($"attachments.{inline}{attachment.Name}", attachment.ContentStream, attachment.Name);
        }
        url.PostAsync(content).Wait();
    }
