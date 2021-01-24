    IamTokenData GetIAMToken(string apikey)
    {
      var wr = (HttpWebRequest)WebRequest.Create("https://iam.bluemix.net/identity/token");
      wr.Proxy = null;
      wr.Method = "POST";
      wr.Accept = "application/json";
      wr.ContentType = "application/x-www-form-urlencoded";
      using (TextWriter tw = new StreamWriter(wr.GetRequestStream()))
      {
        tw.Write($"grant_type=urn:ibm:params:oauth:grant-type:apikey&apikey={apikey}");
      }
      var resp = wr.GetResponse();
      using (TextReader tr = new StreamReader(resp.GetResponseStream()))
      {
        var s = tr.ReadToEnd();
        return JsonConvert.DeserializeObject<IamTokenData>(s);
      }
    }
    IamTokenData tokenData = GetIAMToken([Your IamApiKey]);
    CancellationTokenSource cts = new CancellationTokenSource();
    ClientWebSocket clientWebSocket = new ClientWebSocket();
      
    clientWebSocket.Options.Proxy = null;
    clientWebSocket.Options.SetRequestHeader("Authorization", $"Bearer {token.AccessToken}");
    // Make the sure the following URL is that one IBM pointed you to
    Uri connection = new Uri($"wss://gateway-wdc.watsonplatform.net/speech-to-text/api/v1/recognize");
    try
    {
      //await clientWebSocket.ConnectAsync(connection, cts.Token);
      clientWebSocket.ConnectAsync(connection, cts.Token).GetAwaiter().GetResult();
      Console.WriteLine("Connected!");
    }
    catch (Exception e)
    {
      Console.WriteLine("Failed to connect: " + e.ToString());
      return null;
    }
    // ... Do what you need with the websocket after that ...
