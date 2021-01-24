    JObject contact1 = new JObject();   
    contact1.Add("firstname", "Peter");  
    contact1.Add("lastname", "Cambel");  
    
    HttpRequestMessage createRequest1 = new HttpRequestMessage(HttpMethod.Post, https://xyz.crm.dynamics.com/api/data/v9.0/contacts");  
    createRequest1.Content = new StringContent(contact1.ToString(), Encoding.UTF8, "application/json");  
    HttpResponseMessage createResponse1 = await httpClient.SendAsync(createRequest1);  
    if (createResponse1.StatusCode == HttpStatusCode.NoContent)  //204  
    {  
        Console.WriteLine("Contact '{0} {1}' created.", contact1.GetValue("firstname"), contact1.GetValue("lastname"));  
        contact1Uri = createResponse1.Headers.GetValues("OData-EntityId").FirstOrDefault();  
        entityUris.Add(contact1Uri);  
        Console.WriteLine("Contact URI: {0}", contact1Uri);  
    }  
    else  
    {  
        Console.WriteLine("Failed to create contact for reason: {0}", createResponse1.ReasonPhrase);  
        throw new CrmHttpResponseException(createResponse1.Content);  
    }  
