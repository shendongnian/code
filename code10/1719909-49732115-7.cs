        var client = new ClientWebSocket();
        client.Options.UseDefaultCredentials = true;
        client.Options.SetRequestHeader("X-ConnectionId", System.Guid.NewGuid().ToString());
        client.Options.SetRequestHeader("Authorization", "eyJ0eXAiOiJKV1QiL....16pbFPOWT3VHXot8");
        var a = client.ConnectAsync(new Uri("wss://speech.platform.bing.com/speech/recognition/Dictation/cognitiveservices/v1"), CancellationToken.None);
        a.Wait();
