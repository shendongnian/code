    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
        while(true)
        {
            string data = Encoding.Unicode.GetString(buffer, 0, 
                           streamer.Read(buffer, 0, client.ReceiveBufferSize));
            if(data == "Response_Command_329873123709123")
            {
                var message = Encoding.Unicode.GetString(buffer, 0, 
                                       streamer.Read(buffer, 0, client.ReceiveBufferSize));
 
                worker.ReportProgress (0,  message);
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MessageBox.Show((string)e.UserState, "Client Response");
        }
