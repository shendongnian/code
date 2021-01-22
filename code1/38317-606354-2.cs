    public class Baz : Bar
    {
       private int thisInt;
       override public int SomeProperty 
       {
          get { return thisInt; }
          set 
          {
             if(value < 0)
             {
                throw new ArgumentException("Value must be greater than or equal to zero.");
             }
             thisInt = 0;
          }
       }
    }
