    class SystemArea
    {
        public int Id {get; set;}
        ... // other properties
        // every SystemArea has zero or more SystemAreaFunctionalities (one-to-many)
        public virtual ICollection<SystemAreaFunctionality> SystemAreaFunctionalities {get; set;}
    }
    class SystemAreaFunctionality
    {
        public int Id {get; set;}
        ... // other properties
        
        // every SystemAreaFunctionality belongs to exactly one SystemArea, using foreign key
        public int SystemAreaId {get; set;}
        public virtual SystemArea SystemArea {get; set;}
    }
