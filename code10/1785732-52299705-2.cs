    static async Task DownloadDocumentAsync(Uri uri, string fileName)
    {
        using (var webClient = new WebClient())
        {
            try
            {
                await webClient.DownloadFileTaskAsync(uri, fileName);
            }
            catch (WebException ex)
            {
                Log($"Downloading {uri} failed. {ex.Message}");
                throw;
            }
            catch (InvalidOperationException)
            {
                Log($"Saving {uri} to {fileName} failed. File is in use.");
                throw;
            }
        }
    }
