        [Required]
        public int patientID { get; set; }
    
        [StringLength(255)]
        public string firstName { get; set; }
    
        [StringLength(255)]
        public string lastName { get; set; }
    
        public virtual ICollection<DoctorNote> DoctorNotes { get; set;}
        public virtual ICollection<PatientAllocation> PatientAllocations { get; set; }
    }
