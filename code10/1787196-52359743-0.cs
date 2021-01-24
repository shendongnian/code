    // somewhere in your WCF service
    if (isProductAddedSuccessfully)
    {
        using (var bus = RabbitHutch.CreateBus("host=your-rabbitmq-node"))
        {
            bus.Publish(new NewProductMessage
            {
                Id = product.Id,
                Amount = 1,
                Added = DateTime.Now
            });
        }
    }
