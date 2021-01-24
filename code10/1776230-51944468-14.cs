    class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Junction> Junctions { get; set; }
	}
    class Part
	{
		public int Id { get; set; }
		public int Number { get; set; }
        public string Description { get; set; }
		public virtual ICollection<Junction> Junctions { get; set; }
	}
    class Enumeration
	{
		public int Id { get; set; }
		public int Code { get; set; }
        public virtual ICollection<Junction> Junctions { get; set; }
	}
