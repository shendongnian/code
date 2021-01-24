    abstract class Parent
    {
        protected int i;
        protected Parent(int i)
        {
            this.i = i;
        }
        protected Parent(Func<int> param)
        {
            i = param();
        } 
    }
    class Child : Parent
    {
        public Child(int i) : base(() => i * 2)
        {
            
        }
    }
