    [Authorize]
    [HttpPost, Route("sendForDevelopment")]
    public async Task<IHttpActionResult> Post([FromBody]string message, string installationId) {
        if (string.IsNullOrWhiteSpace(installationId)) {
            var model = new {
                error = new {
                    code = 400,
                    message = "installation id is null or empty"
                }
            }
            return Content(HttpStatusCode.Badrequest, model); //400 Bad Request with error message
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
        return Ok(result); //200 OK with model result
    }
