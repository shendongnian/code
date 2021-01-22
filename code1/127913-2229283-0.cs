    class Base
    {
        public abstract bool IsValid(IAdvertValidator validator);
    }
    
    class Derived1 : Base
    {
        public bool IsValid(IAdvertValidator validator)
        {
            return validator.ValidAdvert(this);
        }
    }
    
    class Derived2 : Base
    {
        public bool IsValid(IAdvertValidator validator)
        {
            return validator.ValidAdvert(this);
        }
    }
    
    interface IAdvertValidator
    {
        bool ValidAdvert(Derived1 d1);
        bool ValidAdvert(Derived2 d2);
    }
