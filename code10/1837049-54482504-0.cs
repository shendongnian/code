    public async Task<LambdaResponseItem> FunctionHandler(ConnectRequest request, ILambdaContext context)
            {
                var client = new AmazonLexClient();
                var response = new PostContentResponse();
                var lambdaInfo = new Dictionary<string, string>();
    
                var contentRequest = new PostContentRequest();
                var postContentStream = new MemoryStream();
                var postContentWriter = new StreamWriter(postContentStream);
                
                try
                {
                    var userInput = request.Details?.Parameters?.GetValueOrDefault("UserInput");
    
                    postContentWriter.Write(userInput); // Grab user input (utterance) value from AWS Connect.
                    postContentWriter.Flush();
                    postContentStream.Position = 0;
    
                    contentRequest.Accept = "text/plain; charset=utf-8";
                    contentRequest.BotName = "IntroGreeting";
                    contentRequest.BotAlias = EnvironmentVariables.IsProduction ? "Production" : "Development"; 
                    contentRequest.ContentType = "text/plain; charset=utf-8";
                    contentRequest.UserId = request.Details?.ContactData?.ContactId;
                    contentRequest.InputStream = postContentStream;
                    contentRequest.SessionAttributes = request.Details?.Parameters?.ToJson(); // * Must be in Json format or request will return error *
    
    
    
                    // POST to Lex
                    response = await client.PostContentAsync(contentRequest);
                    return new LambdaResponseItem(){
                        Content = ""
                         }
    
                }
                catch (Exception ex)
                {
                    context.Logger.Log($"POST Request to Amazon Lex Failed {ex.ToJson()}");
                    }
