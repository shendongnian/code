    public DateTime timeStamp 
        {
            get { return new DateTime(StartTimeTicks); }
            set
            {
                StartTimeTicks = value.Ticks;
            }
        }
    public long StartTimeTicks;
