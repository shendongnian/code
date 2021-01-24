    class MyListBoxItem
    {
        public string StudyBaseFolder { get; set; }
        public string StudyName { get; set; }
        public string UserLastName { get; set; }
        public DateTime StudyDate { get; set; }
        public override string ToString()
        {
            return $"{StudyDate:ddMMyyyy}{StudyName}";
        }
    }    
    
