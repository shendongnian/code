        using (Stream stream = webClient.OpenRead(audioFile))
        {
            var ms = new MemoryStream();
            stream.CopyTo(ms);
            var deviceMetadata = new DeviceMetadata(DeviceType.Near, DeviceFamily.Desktop, NetworkType.Ethernet, OsName.Windows, "1607", "Dell", "T3600");
            var applicationMetadata = new ApplicationMetadata("SampleApp", "1.0.0");
            var requestMetadata = new RequestMetadata(Guid.NewGuid(), deviceMetadata, applicationMetadata, "SampleAppService");
            try
            {
                await speechClient.RecognizeAsync(new SpeechInput(ms, requestMetadata), this.cts.Token).ConfigureAwait(false);
            }
            catch (Exception genEx)
            {
                // Was just using this try/catch for debugging reasons
            }
        }
