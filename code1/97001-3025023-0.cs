    public class Parent
    {
      private int _X;
      public int X{ set{_X=value;} get{return _X;}}
      public Parent copy()
      {
         return new Parent{X=this.X};
      }
    }
    public class Child:Parent
    {
      private int _Y;
      public int Y{ set{_Y=value;} get{return _Y;}}
      public new Child copy()
      {
         return new Child{X=this.X,Y=this.Y};
      }
    }
