    private async void Start_Click(object sender, RoutedEventArgs e)
    {
        Uri resourceAddress;
    
        // The value of 'AddressField' is set by the user and is therefore untrusted input. If we can't create a
        // valid, absolute URI, we'll notify the user about the incorrect input.
        if (!Helpers.TryGetUri(AddressField.Text, out resourceAddress))
        {
            rootPage.NotifyUser("Invalid URI.", NotifyType.ErrorMessage);
            return;
        }
    
        Helpers.ScenarioStarted(StartButton, CancelButton, OutputField);
        rootPage.NotifyUser("In progress", NotifyType.StatusMessage);
    
        try
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, resourceAddress);
    
            // Do not buffer the response.
            HttpResponseMessage response = await httpClient.SendRequestAsync(
                request,
                HttpCompletionOption.ResponseHeadersRead).AsTask(cts.Token);
    
            OutputField.Text += Helpers.SerializeHeaders(response);
    
            StringBuilder responseBody = new StringBuilder();
            using (Stream responseStream = (await response.Content.ReadAsInputStreamAsync()).AsStreamForRead())
            {
                int read = 0;
                byte[] responseBytes = new byte[1000];
                do
                {
                    read = await responseStream.ReadAsync(responseBytes, 0, responseBytes.Length);
    
                    responseBody.AppendFormat("Bytes read from stream: {0}", read);
                    responseBody.AppendLine();
    
                    // Use the buffer contents for something. We can't safely display it as a string though, since encodings
                    // like UTF-8 and UTF-16 have a variable number of bytes per character and so the last bytes in the buffer
                    // may not contain a whole character. Instead, we'll convert the bytes to hex and display the result.
                    IBuffer responseBuffer = CryptographicBuffer.CreateFromByteArray(responseBytes);
                    responseBuffer.Length = (uint)read;
                    responseBody.AppendFormat(CryptographicBuffer.EncodeToHexString(responseBuffer));
                    responseBody.AppendLine();
                } while (read != 0);
            }
            OutputField.Text += responseBody.ToString();
    
            rootPage.NotifyUser("Completed", NotifyType.StatusMessage);
        }
        catch (TaskCanceledException)
        {
            rootPage.NotifyUser("Request canceled.", NotifyType.ErrorMessage);
        }
        catch (Exception ex)
        {
            rootPage.NotifyUser("Error: " + ex.Message, NotifyType.ErrorMessage);
        }
        finally
        {
            Helpers.ScenarioCompleted(StartButton, CancelButton);
        }
    }
      
