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
/
    /with include you can use linq to query ex:
    var IgPosts =  context.Posts.Include(x => x.Category)
                      .FirstOrDefault(x => x.SomeProperty.StartsWith("CoolGuy"));
    
                  //For iteration use eager loads collection explicitly
              var x =    context.Entry(Posts).Collection(x => x.Category).Load();
