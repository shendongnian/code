    [Serializable]
    public class Road 
    {
         [XmlAttribute] public string name;
         [XmlAttribute] public float id;
         
         // ...
         [XmlElement] public Link link; 
    }
    
    [Serializable]
    public class Link {
        [XmlElement] public Successor successor;
    }    
    
    [Serializeable]
    public class Successor
    {
       [XmlAttribute] public string elementId;
       [XmlAttribute] public string elementType;
    }
    [Serializable]
    public class PlanView
    {
        [XmlElement] public Geometry geometry;
    }
    [Serializable]
    public class Geometry 
    {
        [XmlAttribute] public <type> Attribute1;
        [XmlAttribute] public <type> Attribute2;
        [XmlElement] public Line line;
    }
    [Seializable]
    public class Line
    {
        // etc ...
    }
