    using System;
    
    class Base
    {
        public virtual void OverrideMe()
        {
            Console.WriteLine("Base.OverrideMe");
        }
    
        public virtual void HideMe()
        {
            Console.WriteLine("Base.HideMe");
        }
    }
    
    class Derived : Base
    {
        public override void OverrideMe()
        {
            Console.WriteLine("Derived.OverrideMe");
        }
    
        public new void HideMe()
        {
            Console.WriteLine("Derived.HideMe");
        }
    }
    
    class Test
    {
        static void Main()
        {
            Base x = new Derived();
            x.OverrideMe();
            x.HideMe();
        }
    }
