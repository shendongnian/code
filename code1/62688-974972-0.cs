    class ContainingClass : IDisposable
    {
        private PreloadClient m_Client;
        private void Preload(SlideHandler slide)
        {
             m_Client = new PreloadClient())
                        
             m_Client.PreloadCompleted += client_PreloadCompleted;
             m_Client.Preload(slide);
        
        }
        private void client_PreloadCompleted(object sender, SlidePreloadCompletedEventArgs e)
        {
        }
        public void Dispose()
        {
            if (m_Client != null)
                m_Client.Dispose();
        }
    }
