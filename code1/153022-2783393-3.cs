    public class RelationshipRepository
    {
        private List<Relationship> relationships = new List<Relationship>();
    
        public IEnumerable<Relationship> GetRelationships(Node node)
        {
            return relationships.Where(r => r.Child == node || r.Parent == node);
        }
    
        public IEnumerable<Relationship> GetChildRelationships(Node node)
        {
            return relationships.Where(r => r.Parent == node);
        }
    
        public IEnumerable<Relationship> GetParentRelationships(Node node)
        {
            return relationships.Where(r => r.Child == node);
        }
        public void Add(Node parent, Node child, RelationshipType type)
        {
            relationships.Add(new Relationship()
            {
                Parent = parent,
                Child = child,
                Type = type
            });
            parent.RelationshipSource = this;
            child.RelationshipSource = this;
        }
    }
    
    public class Node
    {
        // General properties
    
        public RelationshipRepository RelationshipSource { get; set; }
    
        public IEnumerable<Relationship> Relationships 
        { 
            get { return relationships.GetRelationships(this); }
        }
    
        public IEnumerable<Relationship> Children
        { 
            get { return relationships.GetChildRelationships(this); }
        }
    
        public IEnumerable<Relationship> Parents
        { 
            get { return relationships.GetParentRelationships(this); }
        }
    }
