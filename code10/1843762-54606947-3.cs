    public class Schedule
    {
        public string Subject1 { get; set; }
        public string Subject2 { get; set; }
        public string Subject3 { get; set; }
        public string this[int index]
        {
            get {
                switch (index) {
                    case 1: return Subject1;
                    case 2: return Subject2;
                    case 3: return Subject3;
                    default: return null;
                }
            }
            set {
                switch (index) {
                    case 1: Subject1 = value; break;
                    case 2: Subject2 = value; break;
                    case 3: Subject3 = value; break;
                    default: break;
                }
            }
        }
