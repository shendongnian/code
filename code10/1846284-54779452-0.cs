        private async void StartClient()
        {
            try
            {
                // Create the StreamSocket and establish a connection to the echo server.
                using (var streamSocket = new Windows.Networking.Sockets.StreamSocket())
                {
                    // The server hostname that we will be establishing a connection to. In this example, the server and client are in the same process.
                    var hostName = new Windows.Networking.HostName(TxtHostName.Text);
                    await streamSocket.ConnectAsync(hostName, TxtPortNumber.Text);
                    while(true)
                    {
                        using (var reader = new DataReader(streamSocket.InputStream))
                        {
                            reader.InputStreamOptions = InputStreamOptions.Partial;
                            uint numAudioBytes = await reader.LoadAsync(reader.UnconsumedBufferLength);
                            byte[] audioBytes = new byte[numAudioBytes];
                            reader.ReadBytes(audioBytes);
                            //Parse data to RTP packet
                            audioBytes = Convert_Protocol_LH(audioBytes);
                            var pcmStream = audioBytes.AsBuffer().AsStream().AsRandomAccessStream();
                            MediaElementForAudio.SetSource(pcmStream, "audio/x-wav");
                            MediaElementForAudio.Play();
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                Windows.Networking.Sockets.SocketErrorStatus webErrorStatus = Windows.Networking.Sockets.SocketError.GetStatus(ex.GetBaseException().HResult);
            }
        }
