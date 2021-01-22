    public class Element
    {
     public Element Parent;
     publlc void SetParent(Element parent)
     {
       // this.Parent = parent; // see, you don't need it
       Parent = parent;
     }
    }
    //...
    public class Element
    {
     public Element _parent;
     public Element Parent { get { return _parent; } }
     publlc void SetParent(Element parent)
     {
       // this._parent = parent; // see, you don't need it
       _parent = parent;
     }
    }
