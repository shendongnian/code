    class Model2
    {
        public int Id {set; set;}
        // every Model2 has zero or more Model1s:
        public virtual ICollection<Model1> Model1s {get; set;}
        ...
    }
    class Model1
    {
        public int Id {set; set;}
        // every Model1 belongs to exactly one Model2, using foreign key
        public int Model2Id {get; set;}
        public virtual Model2 Model1 {get; set;}
        ...
    }
