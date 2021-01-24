    class ServerRequester {
        private readonly Object obj = new Object();
        private object Data; // I don't know what is the type of Data
    
        public async Task<Data> requestAndParse()
        {
            lock (this.obj)
            {
                if (this.Data == null)
                {
                    // Wait for request
                    this.response = await client.GetStringAsync(url);
    
                    /**
                    ** 
                    ** parse data
                    ** ...
                    **/
                }
            }
            return this.Data;
        }
    }
