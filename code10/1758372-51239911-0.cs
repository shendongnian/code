    Class A
    {
        // PK
        public string A_Id
    
        // Navigation Property
        public virtual ICollection<B> MyB{ get; set; }
    }
    
    
    Class B
    {
        // PK
        public int B_Id
    
        // FK - On Delete - NO ACTION     <---------- Difference here
        [Required]          <------------------------ SOLUTION =] =] =]
        public string A_Id { get; set; }
    
        // Navigation Properties
        public virtual A MyA { get; set; }
        public List<C> MyC{ get; set; }
    }
    
    Class C
    {
        // PK
        public int C_Id
    
        // FK - On Delete - CASCADE     <---------- Difference here
        public int B_Id { get; set; }
    
        // Navigation Properties
        public virtual B MyB { get; set; }
    }
