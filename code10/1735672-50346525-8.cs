    public static async Task<bool> IsOnline(string hostUri)
    {
        try
        {
            object token = Guid.NewGuid().ToString();
            using (var p = new Ping())
            {
                var result= await p.SendPingAsync(hostNameOrAddress: hostUri, timeout: 1000);
                return result.Status == IPStatus.Success;
            }
        }
        catch (Exception)
        {                
            return false;
        }
    }
