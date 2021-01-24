        public class Date_v01
        {
            public double DateStart;
            public double DateEnd;
            public DateTime DateTimeStart()
            {
                return CoreTime.JD2DateTime(DateStart);
            }
            public DateTime DateTimeEnd()
            {
                return CoreTime.JD2DateTime(DateEnd);
            }
      
            //public DateTime DateStart { get; set; }
            //public DateTime DateEnd { get; set; }
        }
