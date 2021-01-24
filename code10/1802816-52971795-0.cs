    public class CA {
        public int Id {get; set;}
        public CC C {get; set; }
        public ICollection<CB> Bs {get; set;}
    }
    public class CC {
        public int Id {get; set;}
        public int AId {get; set;}
        public virtual CA A {get; set;}
        
        public string V {get; set;}
    }    
    public class CB {
        public int Id {get; set;}
        public int AId {get; set;}
        public virtual CA A {get; set;}
        public string V {get; set;}
    }
