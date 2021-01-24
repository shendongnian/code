    var data = new GetListItemsResult
    {
        SendRecieveShipmentData = new SendRecieveShipmentData[]
        {
            new SendRecieveShipmentData
            {
                Name = "foo"
            }
        },
        RegisteredMailData = new RegisteredMailData[]
        {
            new RegisteredMailData
            {
                Status = "ok"
            }
        }
    };
    string json = JsonConvert.SerializeObject(data);
