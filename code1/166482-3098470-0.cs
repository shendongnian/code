    public class Foo
    {
        /// for new code, and for mapping to the database:
        public int? SomeProperty_new {get;set;}
        
        /// for legacy code only.  Eventually, refactor legacy code to use SomeProperty_new instead, and just remove this needless property.
        [Obsolete("This uses default value to mean null.  Use SomeProperty_new instead.")]
        public int SomeProperty_old
        { 
            get 
            {
                if (SomeProperty_new == null)
                    return 0;
                else
                    return SomeProperty_new;
            }
            set { /* convert from 0 to null if necessary and set to SomeProperty_new.*/ }
        }
    }
