    class Time {
    
        public DateTime StartTime{ get; set; }
        public DateTime EndTime{ get; set; }
    
        public TimeSpan ElapsedTime(){
            return EndTime.subtract(startTime);
        }
    
    }
