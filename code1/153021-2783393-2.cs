    public class Node
    {
        // General properties
        public List<Relationship> Relationships { get; set; }
    }
    
    public class Relationship
    {
        public Node Parent { get; set; }
        public Node Child { get; set; }
        public RelationshipType Type { get; set; }
    }
    
    public enum RelationshipType
    {
        //...
    }
