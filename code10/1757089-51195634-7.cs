    private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
    {
                    
                    var message = await result as Activity;
                    
                    // OLD 
                    //var qnaAuthKey = GetSetting("QnAAuthKey"); 
                    //var qnaKBId = Utils.GetAppSetting("QnAKnowledgebaseId");
                    //var endpointHostName = Utils.GetAppSetting("QnAEndpointHostName"); 
        
                    // NEW
                    var qnaAuthKey = ConfigurationManager.AppSettings["QnAAuthKey"];
                    var qnaKBId = ConfigurationManager.AppSettings["QnAKnowledgebaseId"];
                    var endpointHostName = ConfigurationManager.AppSettings["QnAEndpointHostName"]; 
        
                    // QnA Subscription Key and KnowledgeBase Id null verification
                    if (!string.IsNullOrEmpty(qnaAuthKey) && !string.IsNullOrEmpty(qnaKBId))
                    {
                        // Forward to the appropriate Dialog based on whether the endpoint hostname is present
                        if (string.IsNullOrEmpty(endpointHostName))
                            await context.Forward(new BasicQnAMakerPreviewDialog(), AfterAnswerAsync, message, CancellationToken.None);
                        else
                            await context.Forward(new BasicQnAMakerDialog(), AfterAnswerAsync, message, CancellationToken.None);
                       
                    }
                    else
                    {
                        await context.PostAsync("Please set QnAKnowledgebaseId, QnAAuthKey and QnAEndpointHostName (if applicable) in App Settings. Learn how to get them at https://aka.ms/qnaabssetup.");
                    }
        
                }
