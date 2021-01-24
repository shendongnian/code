    class Program
    {
        static Process webAPI;
    
        static async Task Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
    
            webAPI = new Process
    		{
    			StartInfo = new ProcessStartInfo("dotnet")
    			{
    				UseShellExecute = false,
    				WorkingDirectory = "C:/Project/publish",
    				Arguments = "WebAPI.dll",
    				CreateNoWindow = true
    			}
    		};
    		using (webAPI)
    		{
    			webAPI.Start();
    			webAPI.WaitForExit();
    		}
        }
    
        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            webAPI.Close();
        }
    }
