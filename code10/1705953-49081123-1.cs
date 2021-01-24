    public class Post {
  
      //initialize the list in the constructor --
       public Post(){
    Images = new List<Images>() ;
    }
        public int Id { get; set; }     
        public string Title { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public DateTime Created { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Image> Images { get; set; }
        // .....
    }
