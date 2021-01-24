     private Task ReadSerialUART;
    public void StartSerial()
    {
        CancellationTokenSource source = new CancellationTokenSource(); // create token source
        ReadSerialUART = new Task(() => ReadSerial(source)); //start task
        Thread.Sleep(5000) //lets wait some time before cancelling task
        source.Cancel(); // you can cancel task by calling this anytime
    }
    public void StopSerial()
    {
        //?? ReadSerialUART.Kill();
    }
    public void ReadSerial(CancellationToken token)
    {            
        char Key;
        SerialPort.ReadTimeout = 1000; // with this ReadChar() will throw TimeoutException after 1 sec
        while (1 == 1)
        {
            try
            {
                Key = (char)this.SerialPort.ReadChar();
            }finally
            {
                token.ThrowIfCancellationRequested(); // ternimate thread if token is canceled (source.cancel() is called)
            }
            
            if (Key != 13)
            {
                this.trans.richTextBox_message.Invoke(new Action(() => 
                this.trans.richTextBox_message.Text += Key));
            }
        }            
    }
