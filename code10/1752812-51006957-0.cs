      [Key]
      public int LocationId {get;set;}
      public string Name { get; set; }
      public string Description { get; set; }
      public string Latitude { get; set; }
      public string Longitude { get; set; }
      public Company Company { get; set; }
      [ForeignKey("OpeningTimeId")]
      public OpeningTime OpeningTimes { get; set; }
