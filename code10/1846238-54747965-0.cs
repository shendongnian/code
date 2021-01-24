    class TestTag
    {
        public int Id {get; set;}
        ...  // other properties
        // every TestTag has zero or more TestChildren (one-to-many)
        public virtual ICollection<TestChild> TestChildren {get; set;}
    }
    class TestParent
    {
        public int Id {get; set;}
        ...  // other properties
        // every TestParent has zero or more TestChildren (one-to-many)
        public virtual ICollection<TestChild> TestChildren {get; set;}
    }
    class TestChild
    {
        public int Id {get; set;}
        ...  // other properties
        // every TestChild has exactly one TestParent using foreign key
        public int TestParentId {get; set;}
        public virtual TestParent TestParent {get; set;}
        // every TestChild has exactly one TestTag using foreign key
        public int TestTagId {get; set;}
        public virtual TestTag TestTag {get; set;}
    }
