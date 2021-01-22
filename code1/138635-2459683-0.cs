    class Producer
    {
        public Producer(ExternalSource src)
        {
            src.OnData += externalSource_OnData;
        }
        private void externalSource_OnData(object sender, ExternalSourceDataEventArgs e)
        {
            // put e.Data onto the queue
        }
    }
