    public sealed class Thing
    {  
        public Thing(IEnumerable<Thing> children) {
          this._children = children.ToList().AsReadOnly();
        }
    
        private readonly ReadOnlyCollection<Thing> _children;
    
        public int Id {get; set;}       
        public string Name {get; set;}      
        public IEnumerable<Thing> children {
           get {
             return _children;
           }
        }
    
        public string ToString(int level = 0)
        {
            //Level is added purely to add a visual hierarchy
            var sb = new StringBuilder();
            sb.Append(new String('-',level));
            sb.AppendLine($"id:{Id} Name:{Name}");          
            foreach(var child in children)
            {
                    sb.Append(child.ToString(level + 1));
            }       
            return sb.ToString();
        }   
    }
