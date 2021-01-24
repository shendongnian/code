     public structure OPC_UA
     {
        
        public string data;
        public Int64 quality ;
        public DateTime timeStamp 
        {
            get { return new DateTime(StartTimeTicks); }
            set
            {
                StartTimeTicks = value.Ticks;
            }
        }
        public long StartTimeTicks;
     }
