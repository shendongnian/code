    public class Whatever {
       // private data here
       int _someVal = kSomeConstant;
       // constructor(s)
       public Whatever() { }
    #region FabulousTrick  // sometimes regionize it
       // fabulous trick code
       private int SupportMethodOne() { }
       private double SupportMethodTwo() { }
       public void PerformFabulousTrick(Dog spot) {
           int herrings = SupportMethodOne();
           double pieces = SupportMethodTwo();
           // etc
       }
    #endregion FabulousTrick
       // etc
    }
