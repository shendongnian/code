    DoNotAllowPatchUpdate:Attribute{}
    public class Entity
     {
        [DoNotAllowPatchUpdate]
        public string Id     { get; set; }
    
        public string Name   { get; set; }
    
        public string Status { get; set; }
    
        public string Action { get; set; }
     }
