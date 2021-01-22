    public class A
    {
       public B Child
       {
          get { return this.child; }
          set
          {
             if (this.child != value)
             {
                this.child = value;
                this.child.Parent = this;
             }
          }
       }
       private B child = null;
    }
    public class B
    {
       public A Parent
       {
          get { return this.parent; }
          set
          {
             if (this.parent != value)
             {
                this.parent = value;
                this.parent.Child = this;
             }
          }
       }
       private A parent = null;
    }
