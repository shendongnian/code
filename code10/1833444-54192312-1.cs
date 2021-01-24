        private static async void Connect()
        {
            var hubConnectionBuilder = new HubConnectionBuilder();
            #region Worked
            var hubConnection = hubConnectionBuilder.WithUrl("https://localhost:44381/timeHub", options =>
            {
                
            }).Build();
            #endregion
            await hubConnection.StartAsync();
            await hubConnection.SendAsync("UpdateTime", $"From Client");
            var item1 = new Dictionary<string, object> {
                { "T1", new { Name = "TT1" } },
                { "T2", new { Name = "TT2" } },
                { "T3", new { Name = "TT3" } },
            };
            var item2 = new Dictionary<string, object> {
                { "T11", new { Name = "TT11" } },
                { "T12", new { Name = "TT12" } },
                { "T13", new { Name = "TT13" } },
            };
            await hubConnection.SendAsync("SendMessage", new Message {
                MessageId = 1,
                Items = new List<Dictionary<string, object>> {
                    item1,
                    item2
                },
                TextMessages = new List<string> {
                    "H1",
                    "H2"
                }
            });
            var on = hubConnection.On("ReceiveMessage", OnReceivedAction);
            Console.WriteLine($"Client is Start");
            Console.ReadLine();
            on.Dispose();
            await hubConnection.StopAsync();
        }
