    public static string Ping(string url)
    {
        Process p = System.Diagnostics.Process.Start("ping.exe", url);
        StreamReader reader = p.StandardOutput;
        
        String output = reader.ReadToEnd();
        reader.Close();
    
        return output;
    }
