    public async Task Pair(string deviceName) {
        // Setup a handler that ignores invalid certificates only for this HttpClient
        using (var handler = new HttpClientHandler {
            ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
        })
        using (var httpClient = new HttpClient(handler))
        try {
            httpClient.BaseAddress = new Uri($"https://{televisionIPAddress}:9000");
            deviceID = Guid.NewGuid().ToString();
            var startPairingRequest = new HttpRequestMessage(HttpMethod.Put, "/pairing/start");
            startPairingRequest.Content = CreateStringContent(new PairingStartRequestBody {
                DeviceID = deviceID,
                DeviceName = deviceName
            });
            var startPairingResponse = await httpClient.SendAsync(startPairingRequest);
            Console.WriteLine(startPairingResponse);
        } catch (HttpRequestException e) {
            Console.WriteLine(e.InnerException.Message);
        }
    }
    StringContent CreateStringContent(object obj) {
        return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
    }
