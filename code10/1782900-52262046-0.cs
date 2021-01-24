    [HttpPost]
            public dynamic DialogAction([FromBody] WebhookRequest dialogflowRequest)
            {
                var intentName = dialogflowRequest.QueryResult.Intent.DisplayName;
                var actualQuestion = dialogflowRequest.QueryResult.QueryText;
                var testAnswer = $"Dialogflow Request for intent {intentName} and question {actualQuestion}";
                var parameters = dialogflowRequest.QueryResult.Parameters;
                var dialogflowResponse = new WebhookResponse
                {
                    FulfillmentText = testAnswer,
                    FulfillmentMessages =
                    { new Intent.Types.Message
                        { SimpleResponses = new Intent.Types.Message.Types.SimpleResponses
                            { SimpleResponses_ =
                                { new Intent.Types.Message.Types.SimpleResponse
                                    {
                                       DisplayText = testAnswer,
                                       TextToSpeech = testAnswer,
                                    }
                                }
                            }
                        }
                    }
                };
                var jsonResponse = dialogflowResponse.ToString();
                return new ContentResult { Content = jsonResponse, ContentType = "application/json" }; ;
                //return "Connecteds";
            }
