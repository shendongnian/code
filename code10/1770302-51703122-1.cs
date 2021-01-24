    static async Task<string> DoRequestHandling(HttpWebRequest request, byte[] arrByteData, CancellationToken cancelToken)
    {
        string strReturn = String.Empty;
        var requestStream = await request.GetRequestStreamAsync()
            .ConfigureAwait(false);
        if (!cancelToken.IsCancellationRequested)
        {
            requestStream.Write(arrByteData, 0, arrByteData.Length);
            requestStream.Close();
            if (!cancelToken.IsCancellationRequested)
            {
                using (var response = await request.GetResponseAsync().ConfigureAwait(false) as HttpWebResponse)
                using (var responseStream = response.GetResponseStream())
                using (var responseStreamReader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    strReturn = await responseStreamReader.ReadToEndAsync()
                        .ConfigureAwait(false);
                }
            }
            else
            {
                // Request was cancelled -> exit
            }
        }
        else
        {
            // Request was cancelled -> exit
        }
        return strReturn;
    }
