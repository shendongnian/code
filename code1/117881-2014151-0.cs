    public class Element{
    //...
    public Element Parent;
    public Element Root()
    {
     if( Parent == null )
      return this;
     return Parent.Root();
    }
    }
    public void OnEvent()
    {
     Event(this, new EventArgs());
    }
    
