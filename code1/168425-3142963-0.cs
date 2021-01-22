    public class Parent
    {
        public virtual Parent me()
        {
            return this;
        }
    }
    public class Child : Parent
    {
        new public Child me ()
        {
            return this;
        }
    }
