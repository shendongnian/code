    private class TimeLapse
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double GetSecondsPassed() {
            return (EndTime - StartTime).TotalSeconds
        }
    }
