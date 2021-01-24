    using System;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.IO.Compression;
    using System.Security.Cryptography;
    using Microsoft.AspNet.SignalR.Client;
    
    namespace WebsocketSample
    {
        public sealed class BittrexWebsocket
        {
            public delegate void BittrexCallback(string info);
    
            private HubConnection   _hubConnection       { get; }
            private IHubProxy       _hubProxy            { get; }
            private BittrexCallback _updateExchangeState { get; }
            private BittrexCallback _updateOrderState    { get; }
            private BittrexCallback _updateBalanceState  { get; }
    
            public BittrexWebsocket(
                string          connectionUrl, 
                BittrexCallback updateExchangeState,
                BittrexCallback updateOrderState, 
                BittrexCallback updateBalanceState
                )
            {
                // Set delegates
                _updateExchangeState = updateExchangeState;
                _updateOrderState    = updateOrderState;
                _updateBalanceState  = updateBalanceState;
    
                // Create connection to c2 SignalR hub
                _hubConnection = new HubConnection(connectionUrl);
                _hubProxy      = _hubConnection.CreateHubProxy("c2");
    
                // Register callback for uE (exchange state delta) events
                _hubProxy.On(
                    "uE", 
                    exchangeStateDelta => _updateExchangeState?.Invoke(exchangeStateDelta)
                    );
                
                // Register callback for uO (order status change) events
                _hubProxy.On(
                    "uO", 
                    orderStateDelta => _updateOrderState?.Invoke(orderStateDelta)
                    );
                
                // Register callback for uB (balance status change) events
                _hubProxy.On(
                    "uB", 
                    balanceStateDelta => _updateBalanceState?.Invoke(balanceStateDelta)
                    );
    
                _hubConnection.Start().Wait();
            }
    
            public void Shutdown() => _hubConnection.Stop();
    
            // marketName example: "BTC-LTC"
            public async Task<bool> SubscribeToExchangeDeltas(string marketName) => await _hubProxy.Invoke<bool>("SubscribeToExchangeDeltas", marketName);
    
            // The return of GetAuthContext is a challenge string. Call CreateSignature(apiSecret, challenge)
            // for the response to the challenge, and pass it to Authenticate().
            public async Task<string> GetAuthContext(string apiKey) => await _hubProxy.Invoke<string>("GetAuthContext", apiKey);
    
            public async Task<bool> Authenticate(string apiKey, string signedChallenge) => await _hubProxy.Invoke<bool>("Authenticate", apiKey, signedChallenge);
    
            // Decode converts Bittrex CoreHub2 socket wire protocol data into JSON.
            // Data goes from base64 encoded to gzip (byte[]) to minifed JSON.
            public static string Decode(string wireData)
            {
                // Step 1: Base64 decode the wire data into a gzip blob
                byte[] gzipData = Convert.FromBase64String(wireData);
    
                // Step 2: Decompress gzip blob into minified JSON
                using (var decompressedStream = new MemoryStream())
                using (var compressedStream = new MemoryStream(gzipData))
                using (var deflateStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
                {
                    deflateStream.CopyTo(decompressedStream);
                    decompressedStream.Position = 0;
    
                    using (var streamReader = new StreamReader(decompressedStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
    
            public static string CreateSignature(string apiSecret, string challenge)
            {
                // Get hash by using apiSecret as key, and challenge as data
                var hmacSha512 = new HMACSHA512(Encoding.ASCII.GetBytes(apiSecret));
                var hash = hmacSha512.ComputeHash(Encoding.ASCII.GetBytes(challenge));
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }
        
        class Program
        {
            static public BittrexWebsocket.BittrexCallback CreateCallback(string name)
            {
                //
                // In a real app, your code would do something useful based on the
                // information accompanying each event.
                //
    
                return (info) => 
                {
                    Console.WriteLine($"Callback Invoked: {name}");
                    
                    Console.WriteLine(
                        BittrexWebsocket.Decode(info)
                        );
                };
            }
    
            static void Main(string[] args)
            {
                Task task = Task.Run(
                    async () => 
                    {
                        string apiKey    = "YOUR_API_KEY";
                        string apiSecret = "YOUR_API_SECRET";
                        string baseUrl   = "https://beta.bittrex.com/signalr";
    
                        var btx = new BittrexWebsocket(
                            baseUrl, 
                            CreateCallback("exchange"), 
                            CreateCallback("order"), 
                            CreateCallback("balance")
                            );
    
                        // If we successfully authenticate, we'll be subscribed to the uO and uB events.
                        var isAuthenticated = await btx.Authenticate(
                            apiKey,
                            BittrexWebsocket.CreateSignature(apiSecret, await btx.GetAuthContext(apiKey))
                            );
    
                        // Register for orderbook updates on the BTC-ETH market
                        await btx.SubscribeToExchangeDeltas("BTC-ETH");
                    });
    
                task.Wait();
    
                Console.WriteLine("Press enter to exit sample...");
                Console.ReadLine();
            }
        }
    }
