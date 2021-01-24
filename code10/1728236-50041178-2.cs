    using (var client = new System.Net.Http.HttpClient()) {
        var json = JsonConvert.SerializeObject(newPiece);            
        var content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
        await client.PostAsync(App.BaseUri, content);           
    }
