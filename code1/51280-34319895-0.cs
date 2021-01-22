    public class AsOfdates
    {
        public string DisplayDate { get; set; }
        private DateTime TheDate;
        public DateTime DateValue { get { return TheDate.Date; } set { TheDate = value; } }
        
    }
}
