    public class First
    {
       public int x = 0;
       public Second second;
       public First()
       {
          second = new Second(this);
       }    
    
       public run()
       {
          second.change();
       }
       
       public modifyX(int changedX)
       {
           x = changedX
       }
    
    }
    public class Second
    {
       private First _first;
       public Second(First first)
       {
           _first = first;
       }
    
       public change()
       {
          _first.modifyX(2);
       }
    }
