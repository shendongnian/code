    // more work is required to make this even close to production ready
    class Time
    {
        // TODO: don't forget to add validation
        public int Hours   { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public override string ToString()
        {  
            return String.Format(
                "{0:00}:{1:00}:{2:00}",
                this.Hours, this.Minutes, this.Seconds);
        }
    }
