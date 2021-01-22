        private object DoAsynchronousCallSynchronously()
        {
            AutoResetEvent are = new AutoResetEvent(false);
            AsynchronousObject obj = new AsynchronousObject();    
            obj.OnCompletedCallback += delegate 
            {
                are.Set();
            };    
            obj.StartWork();    
            are.WaitOne();
            // StartWork() has completed at this point.    
            return obj.Result;
        }
