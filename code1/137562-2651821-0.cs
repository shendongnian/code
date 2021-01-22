	public FTDISample()
	{
        private AutoResetEvent receivedDataEvent;
        private BackgroundWorker dataReceivedHandler;
        private FTDI ftdi;
        public FTDISample(string serialNumber){
            ftdi = new FTDI();
            FTDI.FT_STATUS status = ftdi.OpenBySerialNumber(serialNumber);
            receivedDataEvent = new AutoResetEvent(false);
            status = mFTDI.SetEventNotification(FTDI.FT_EVENTS.FT_EVENT_RXCHAR, receivedDataEvent);
            dataReceivedHandler = new BackgroundWorker();
            dataReceivedHandler.DoWork += ReadData;
            if (!dataReceivedHandler.IsBusy)
            {
                dataReceivedHandler.RunWorkerAsync();
            }
        }
        private void ReadData(object pSender, DoWorkEventArgs pEventArgs)
        {
            UInt32 nrOfBytesAvailable = 0;
            while (true)
            {
                // wait until event is fired
                this.receivedDataEvent.WaitOne();
                // try to recieve data now
                FTDI.FT_STATUS status = ftdi.GetRxBytesAvailable(ref nrOfBytesAvailable);
                if (status != FTDI.FT_STATUS.FT_OK)
                {
                    break;
                }
                if (nrOfBytesAvailable > 0)
                {
                    byte[] readData = new byte[nrOfBytesAvailable];
                    UInt32 numBytesRead = 0;
                    status = mFTDI.Read(readData, nrOfBytesAvailable, ref numBytesRead);
                    
                    // invoke your own event handler for data received...
                    //InvokeCharacterReceivedEvent(fParsedData);
                }
            }
        }
        public bool Write(string data)
        {
            UInt32 numBytesWritten = 0;
            ASCIIEncoding enconding = new ASCIIEncoding();
            byte[] bytes = enconding.GetBytes(data);
            FTDI.FT_STATUS status = ftdi.Write(bytes, bytes.Length, ref numBytesWritten);
            if (status != FTDI.FT_STATUS.FT_OK)
            {
                Debug.WriteLine("FTDI Write Status ERROR: " + status);
                return false;
            }
            if (numBytesWritten < data.Length)
            {
                Debug.WriteLine("FTDI Write Length ERROR: " + status + " length " + data.Length +
                                " written " + numBytesWritten);
                return false;
            }
            return true;
        }
