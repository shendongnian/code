    using (var webClient = new System.Net.WebClient())
    {
    	webClient.Headers.Add ("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        var json = webClient.DownloadString(fullurl);
        Dts.Variables["User::outputJSON"].Value = json;
        Dts.TaskResult = (int)ScriptResults.Success;
    }
