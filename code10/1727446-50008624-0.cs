     public partial class Review
     {
        public int id { get; set; }
        public string Username { get; set; }
        public string Summary { get; set; }
        public double Rating { get; set; }
       public virtual Restaurant Restaurant { get; set; }
     }
