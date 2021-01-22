    public class Node
    {
         public int Id {get;set;}
         public string Name {get;set;}
         public string Description{get;set;}
         public Dictionary<RelationShipType,IEnumerable<Node>> ChildNodes {get;set;}
    }
    
    public enum RelationShipType
    {
       ....
    }
