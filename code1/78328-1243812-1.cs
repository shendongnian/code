    [RdfSerializable] 
    public class Type2 
    { 
        [RdfProperty(true, Name = "title", 
                   DomainAsType = new Type[]{typeof(Type1), typeof(Type2)},
                   UseLocalRestrictionInsteadOfDomain = true)] 
        public string Title { get; set; } 
    } 
