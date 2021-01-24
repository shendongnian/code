    public async void UpdateMailCategory(GraphServiceClient graphClient, string messageId, string inbox)
    {
        try
        {
            await graphClient
                .Users[inbox]
                .Messages[messageId]
                .Request()
                .UpdateAsync(new Message()
                {
                    Categories = new List<string>() { "Processed" }
                });
        }
        catch (ServiceException Servex)
        {
            throw Servex;
        }
    }
   
