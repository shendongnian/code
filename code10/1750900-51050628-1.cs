                try
                {
                    await connector.Conversations.SendToConversationAsync((Activity)message);
                }
                catch (ErrorResponseException e)
                {
                    Console.WriteLine("Error: ", e.StackTrace);
                }
