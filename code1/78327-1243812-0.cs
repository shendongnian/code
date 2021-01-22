    [RdfSerializable] 
    public class Type1 
    { 
        [RdfProperty(true, Name = "title", ExcludeFromOntology=true)] 
        public string Title { get; set; } 
    } 
     
    [RdfSerializable] 
    public class Type2 
    { 
        [RdfProperty(true, Name = "title", 
                   DomainAsType = new Type[]{typeof(Type1), typeof(Type2)})] 
        public string Title { get; set; } 
    } 
