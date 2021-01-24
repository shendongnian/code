    public static Guid? GetMessageIdFromContext(object context, Type contextType) 
        {
            Guid? messageId = null;
            try
            {
                var contextProp = contextType.GetProperty("Message");
                if (contextProp != null)
                {
                    var message = contextProp.GetValue(context);
                    if (message != null)
                    {
                        messageId = message.GetType().GetProperty("UniqueId").GetValue(message) as Guid?;
                    }
                }
            }
            catch (NullException nullException)
            {
                Console.WriteLine("Could not retrieve message Id from context as the message Id did not exist");
            }
            return messageId;
        }
