        protected override Dispose(bool disposing)
        {
            foreach (PreloadClient client in _activeClients)
            { 
                client.PreloadCompleted -= client_PreloadCompleted;
                client.Dispose();
            }
            _activeClients.Clear();
            base.Dispose(disposing);
        }
