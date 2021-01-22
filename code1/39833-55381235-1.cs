    public Stream GetCurrentCart()
    {
        //Code ommited
        var j = new { Content = response.Content, Display=response.Display,
                      SubTotal=response.SubTotal};
        var s = new JavaScriptSerializer();
        string jsonClient = s.Serialize(j);
        WebOperationContext.Current.OutgoingResponse.ContentType =
            "application/json; charset=utf-8";
        return new MemoryStream(Encoding.UTF8.GetBytes(jsonClient));
    }
