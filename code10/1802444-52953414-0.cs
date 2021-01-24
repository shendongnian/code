    public class ProcessSupervisor
    {
        public int ID { get; set; }
        public int MaximumConcurrentProcesses { get; set; }
        [NotMapped]
        private int? availableProcessSlots = null;
        public int AvailableProcessSlots
        {
            get
            {
                return availableProcessSlots ?? MaximumConcurrentProcesses;
            }
            set
            {
                availableProcessSlots = value;
            }
        }
    }
