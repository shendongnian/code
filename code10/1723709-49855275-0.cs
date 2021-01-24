            WebClient webClient = new WebClient();
            Log("Downloading File from web...");
            try
            {
                webClient.DownloadFile(new Uri(uri), downloadLocation);
                Log("Download from web complete");
                webClient.Dispose();
            }
            catch (Exception ex)
            {
                Log("Error Occurred in downloading file. See below for exception details");
                Log(ex.Message);
                webClient.Dispose();
            } 
