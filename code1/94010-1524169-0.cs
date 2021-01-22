    public class DocumentScannedEventArgs : EventArgs
    {
        public DocumentScannedEventArgs(string scannedText)
        {
            ScannedText= scannedText;
        }
    
        public string ScannedText { get; set }
    }
    
    ...
    
    public class MySerialPort : SerialPort
    {
        public MySerialPort()
        {
            ...
            this.DataReceived += scanner.MyDataReceivedEventHandler;
            ...
        }
        ...
    
        public event EventHandler<DocumentScannedEventArgs> DocumentScanned;
    
        protected void OnDocumentScanned(DocumentScannedEventArgs e)
        {
            var handler = DocumentScanned;
    
            if (handler != null)
            {
                handler(this, e);
            }
        }
        private void MyDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            ...
            this.BeginInvoke(new DisplayDataDelegate(DisplayData), receivedText);
            ...
        }
        private void DisplayData(string receivedText)
        {
            // fire DocumentScanned event
            OnDocumentScanned(new DocumentScannedEventArgs(receivedText));
        }
    }
