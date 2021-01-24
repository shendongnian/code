    public static bool IsListing(string hostUri, int portNumber, int millisecondTimeOut=500)
    {
        try
        {
            var info = new ProcessStartInfo() {
                Arguments = "-a -p TCP",
                CreateNoWindow=false,
                FileName="netstat",
                WindowStyle= ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };
            using (var p = Process.Start(info))
            using (StreamReader reader = p.StandardOutput)
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line.Contains($":{portNumber}"))
                    {
                        return true;
                    }
                }
    
            }
            return false;
    
        }
        catch (SocketException)
        {
            return false;
        }
    
    }
