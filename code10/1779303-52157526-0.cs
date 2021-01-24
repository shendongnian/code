    string json = @"{
        ""contactName"": ""Company"",
        ""lineItems"": [
         {
            ""quantity"": 7.0,
            ""description"": ""Beer No* 45.5 DIN KEG""
         },
         {
            ""quantity"": 2.0,
            ""description"": ""Beer Old 49.5 DIN KEG""
         }
         ],
        ""invoiceNumber"": ""C6188372""
    }";
    
    StringBuilder sb = new StringBuilder();
    using (var p = ChoJSONReader.LoadText(json))
    {
        using (var w = new ChoCSVWriter(sb)
            .WithFirstLineHeader()
            )
            w.Write(p
                .SelectMany(r1 => ((dynamic[])r1.lineItems).Select(r2 => new
                {
                    r1.contactName,
                    r2.quantity,
                    r2.description,
                    r1.invoiceNumber
                })));
    }
    Console.WriteLine(sb.ToString());
