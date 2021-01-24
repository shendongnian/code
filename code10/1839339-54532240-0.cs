    class CarMake
    {
        public int CarMakeId { get; set; }
        public string CarMakeName { get; set; }
        // every CarMake makes zero or more CarModels (many-to-many)
        public virtual ICollection<CarModel> CarModels { get; set; }
    }
    class CarModel
    {
        public int CarModelId { get; set; }
        public string CarModelName { get; set; }
        // every CarModel is made by zero or more CarMakes (many-to-many)
        public virtual ICollection<CarMake> CarMakes {get; set;}
    }
