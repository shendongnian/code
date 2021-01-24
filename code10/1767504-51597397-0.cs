          Cinema:
          public int Id{get;set;}
          public double Price{get;set;}
          public ICollection<Actor> Actor{get;set;}
          public Cinema(){
             this.Actors = new List<Actor>();
          }
