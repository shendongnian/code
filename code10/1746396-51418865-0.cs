    public class ProgressHandler
    {
        public int Progress { get; set; }
        public int MaxProgress { get; set; }
        public int Percentage { get; set; }
        public String PercentageStr { get; set; }
        public String[] Events { get; set; }
        
        public String Statut { get; set; }
        public static ProgressHandler PH { get; set; }
        public ProgressHandler()
        { }
        public ProgressHandler(int maxProgress)
        {
            MaxProgress = maxProgress;
            PH = this;
        }
        public static ProgressHandler Current()
        {
            return PH;
        }
        public void Init()
        {
            Progress = 0;
            MaxProgress = 0;
            Statut = "Waiting";
        }
        public int GetPercentage()
        {
            if (MaxProgress != 0)
            {
                return (int)(((float)Progress / (float)MaxProgress) * 100);
            }
            else
            {
                return 0;
            }
        }
        public int EventSize()
        {
            if(Events!=null)
            {
                return Events.Count();
            }
            return 0;
        }
    }
