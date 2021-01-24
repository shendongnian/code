        [FunctionName("FunctionTest")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [ServiceBus(queueOrTopicName:"queueName",Connection ="ServiceBusConnection")]IAsyncCollector<Message> outputMessages,
            ILogger log)
        {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var message = new Message
                {
                    Body = System.Text.Encoding.UTF8.GetBytes(requestBody),
                    MessageId = "MyMessageId"
                };
                await outputMessages.AddAsync(message);
        }
