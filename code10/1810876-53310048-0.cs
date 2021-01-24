    [Authorize]
    [HttpPost, Route("sendForDevelopment")]
    public async Task<IHttpActionResult> Post([FromBody]string message, string installationId) {
        if (string.IsNullOrWhiteSpace(installationId)) {
            ModelState.AddError("installationId", "installation id is null or empty");
            return BadRequest(ModelState);
        }
        string hubName = "myHubName";
        string hubNameDefaultShared = "myHubNameDefaultShared";
        var hub = NotificationHubClient
                        .CreateClientFromConnectionString(hubNameDefaultShared, hubName, enableTestSend: true);
        var templateParams = new Dictionary<string, string>
        {
            ["messageParam"] = message
        };
        NotificationOutcome result = await hub.SendTemplateNotificationAsync(templateParams, "$InstallationId:{" + installationId + "}").ConfigureAwait(false);
        return Ok(result);
    }
