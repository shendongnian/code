    public class Updater
    {
        public delegate void DataReceivedEventHandler(object sender,DataEventArgs e);
        public event DataReceivedEventHandler DataReceived = delegate { };
        public void ReadData()
        {
            //here you will get data from what ever you like
            //upon recipt of data you will raise the event.
            
            //THIS LOOP IS FOR TESTING ONLY
            for (var i = 1; i < 101; i++)
            {
                //PASS REAL DATA TO new DataEventArgs
                DataReceived(this, new DataEventArgs("Event " + i));
                Thread.Sleep(500);
            }
        }
    }
    public class DataEventArgs : EventArgs
    {
        public string Data { get; set; }
        public DataEventArgs(string data) : base()
        {
            Data = data;
        }
    }
