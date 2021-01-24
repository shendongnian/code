    public class ViewModel 
    {
        private string bytesSum;
        public string BytesSum
        {
            get { return bytesSum; }
            set { bytesSum = value; this.NotifyPropertyChanged("BytesSum"); }
        }
        public ViewModel()
        {
            ChannelFactory<IService> channel = new ChannelFactory<IService>(new NetTcpBinding(), new EndpointAddress(@"net.tcp://localhost:8554/"));
            IService s = channel.CreateChannel();
            //How to get data from server and update UI?
            s.GetData().ToList().ForEach(b => Console.Write(b));
        }
        private void NotifyPropertyChanged(String propertyName = "")
        {
            
        }
    }
