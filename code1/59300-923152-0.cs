    public class RemotingEngine {
        private uint CurrentValueID { get; set; }
        private object Lock { get; set; }
        public RemotingEngine()
        {
            this.CurrentValueID = 0; // not really necessary...
            this.Lock = new object();
        }
    }
