	#define PARALLEL
	
    public class DomePositioningModel
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public DomePositioningModel()
        {
            _httpClient.Timeout = TimeSpan.FromMilliseconds(50);
        }
        public async Task ScanForModulesAsync(Action<PositioningModule> AddModule)
        {
            List<string> ipAddressList = new List<string>();
            var addressBytes = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).GetAddressBytes();
            for (addressBytes[3] = 1; addressBytes[3] < 255; ++addressBytes[3])
            {
                ipAddressList.Add(new IPAddress(addressBytes).ToString());
            }
            //Ping ping = new Ping(); - this behaves strangely, use "new Ping()" instead of "ping"
	#if PARALLEL
            var tasks = ipAddressList.Select(async ipAddress => // much faster
	#else
            foreach (string ipAddress in ipAddressList) // much slower
	#endif
            {
                PingReply pingReply = await new Ping().SendPingAsync(ipAddress, 10); // use "new Ping()" instead of "ping"
                if (pingReply.Status == IPStatus.Success)
                {
                    try
                    {
                        string status = await _httpClient.GetStringAsync("http://" + ipAddress + ":8080" + "/status");
                        if (Enum.TryParse(status, true, out PositioningModuleStatus positioningModuleStatus))
                        {
                            AddModule?.Invoke(new PositioningModule(ipAddress, positioningModuleStatus));
                        }
                    }
                    catch (TaskCanceledException) // timeout
                    {
                    }
                    catch (HttpRequestException) // could not reach IP
                    {
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message);
                    }
                }
            }
	#if PARALLEL
            );
            await Task.WhenAll(tasks);
	#endif
        }
    }
