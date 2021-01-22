        // keep a list of strong references to avoid garbage collection,
        // and dispose them all in case we're disposing the encapsulating object
        private readonly List<PreloadClient> _activeClients = new List<PreloadClient>();
        private void Preload(SlideHandler slide)
        {
            PreloadClient client = new PreloadClient();
            _activeClients.Add(client);
            client.PreloadCompleted += client_PreloadCompleted;
            client.Preload(slide);
        }
        private void client_PreloadCompleted(object sender,
             SlidePreloadCompletedEventArgs e)
        {
            PreloadClient client = sender as PreloadClient;
            // do stuff
            client.PreloadCompleted -= client_PreloadCompleted;
            client.Dispose();
            _activeClients.Remove(client);
        }
