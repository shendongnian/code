    class Program
    {
        private static string mytoken = "";
        private static CancellationTokenSource cancellationToken = new CancellationTokenSource();
        private static bool playing = false;
        private static AudioOutStream dstream = null;
        private static IAudioClient client = null;
        static void Main(string[] args)
        {
            var Client = new DiscordSocketClient();
            Client.LoginAsync(TokenType.Bot, mytoken).Wait();
            Client.StartAsync().Wait();
            var path = "path\\testfile.mp3";
            Client.Ready += async () =>
            {
                var guild = Client.Guilds.First();
                var channel = guild.Channels.Where(x => x is SocketVoiceChannel).Select(x => x as SocketVoiceChannel).First();
                try
                {
                    client = await channel.ConnectAsync();
                    var reader = new Mp3FileReader(path);
                    var naudio = WaveFormatConversionStream.CreatePcmStream(reader);
                    
                    dstream = client.CreatePCMStream(AudioApplication.Music);
                    byte[] buffer = new byte[naudio.Length];
                    int rest = (int)(naudio.Length - naudio.Position);
                    await naudio.ReadAsync(buffer, 0, rest);
                    playing = true;
                    await dstream.WriteAsync(buffer, 0, rest, cancellationToken.Token);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    if(e.InnerException != null)
                        Debug.WriteLine(e.InnerException.Message);
                }
            };
            
            while (!playing) ;
            Console.ReadLine();
            cancellationToken.Cancel();
            Debug.WriteLine("Pre-Flush");
            dstream.Flush();
            Debug.WriteLine("POST-FLUSH");
            client.StopAsync().Wait();
            Client.StopAsync().Wait();
            Client.LogoutAsync().Wait();
        }
    }
