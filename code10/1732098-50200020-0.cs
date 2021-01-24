    public static async Task<bool> PingServer() {
        using (var ping = new System.Net.NetworkInformation.Ping()) {
            try {
                var maxDelay = TimeSpan.FromSeconds(2); //Adjust as needed
                var tokenSource = new CancellationTokenSource(maxDelay);
                System.Net.NetworkInformation.PingReply PR = await Task.Run(() => 
                    ping.SendPingAsync("pc2"), tokenSource.Token);
                // check when the ping is not success
                if (PR.Status != System.Net.NetworkInformation.IPStatus.Success) {
                    return false;
                }
                return true;
            } catch {
                return false;
            }
        }
    }
    
