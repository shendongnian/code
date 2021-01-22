        public List<Inquiry> GetInquiries(string fromDate, string toDate, 
                                                        string subject, string press,
                                                        string cia, string media) 
        {
    // Pass empty string for status.
           return this.GetInquiries(fromDate, toDate, subject, press, cia, media, String.Empty) 
        }
        
        public List<Inquiry> GetInquiries(string fromDate, string toDate, 
                                                        string subject, string press,
                                                        string cia, string media, 
                                                        string status) 
