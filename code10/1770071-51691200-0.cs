    public async Task<dynamic> SendMail(string accessToken, MailWrapper mail)
            {
                try
                {
                    GraphServiceClient graphClient = SDKHelper.GetMicrosoftAuthenticatedClient(accessToken);
                    Message message = await BuildEmailMessage(graphClient, mail);
                    await graphClient.Me.SendMail(message, true).Request().PostAsync(CancellationToken.None);
                    var response = await graphClient.Me.MailFolders.SentItems.Messages.Request()
                                            .OrderBy(sendDateTimeDesc)
                                            .Top(1)
                                            .GetAsync();
                    return await Task.FromResult(response);
                }
                catch (ServiceException ex)
                {
                    throw ex;
                }
            }
