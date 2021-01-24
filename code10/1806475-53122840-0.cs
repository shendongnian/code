    class SerialWorker
    {
        ActionBlock<Data>  _serialBlock;
        public SerialWorker()
        {    
            _serialBlock=new ActionBlock<Data>(data=>DoWork(data));
        }
        //The worker action can be synchronous 
        private void DoWork(Data data)
        {
        }
        //or asynchronous
        private async Task DoWorkAsync(Data data)
        {
        }
        //Producer Code
        //While the application runs :
        public void PostData(Data data)
        {
            _serialBlock.Post(someData);
        }
    
    //When the application finishes 
    //Tell the block to shut down and wait for it to process any leftover requests
        public async Task Shutdown()
        {
            _serialBlock.Complete();    
            await _serialBlock.Completion;
        }
