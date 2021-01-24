        private void ProcessBroadcast()
        {
            //foreach (var number in Numbers)
            //{
            //    //Send a Message here
            //    messageWorker.RunWorkerAsync(message);
            //}
            messageWorker.EnableProgressReporting = true;
            messageWorker.RunWorkerAsync(Numbers);
        } 
