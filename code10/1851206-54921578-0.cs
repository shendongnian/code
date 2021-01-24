    class Enquiry
    {
        public int Id {get; set; }
        public string EnquiryNo { get; set; }
        public DateTime? EnquiryDate { get; set; }
        public string status { get; set; }
        ...
        // every Enquiry has zero or more FollowUps (one-to-many)
        public virtual ICollection<FollowUp> FollowUps {get; set;}
    }
    class FollowUp
    {
        public int Id {get; set; }
        public DateTime FollowupDate { get; set; }
        ...
        // every FollowUp belongs to exactly one Enquiry, using foreign key
        public int EnquiryId {get; set;}
        public virtual Enquiry Enquiry {get; set;}
    }
