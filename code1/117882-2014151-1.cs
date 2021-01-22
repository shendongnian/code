    public class Extension
    {
     public Element Root(this Element element) {
      if( element.Parent == null )
       return element;
      return element.Parent.Root();
     }
    }
