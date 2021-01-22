    public class Base
    {
        public string Name
        {
            get;
            virtual set;
        }
    }
    
    public class Subclass : Base
    {
        // FIXME Unsure as to the exact syntax.
        public string Name
        {
            override set
            {
                if (value != base.Name)
                {
                    RaiseEvent();
                }
    
                base.Name = value;
            }
        }
    }
