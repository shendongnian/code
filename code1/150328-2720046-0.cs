    namespace SO2719954
    {
        class Base { }
        class Descendant : Base { }
    
        interface IBibbleOut<out T> { }
        interface IBibbleIn<in T> { }
    
        class Program
        {
            static void Main(string[] args)
            {
                // We can do this since every Descendant is also a Base
                // and there is no chance we can put Base objects into
                // the returned object, since T is "out"
                // We can not, however, put Base objects into b, since all
                // Base objects might not be Descendant.
                IBibbleOut<Base> b = GetOutDescendant();
    
                // We can do this since every Descendant is also a Base
                // and we can now put Descendant objects into Base
                // We can not, however, retrieve Descendant objects out
                // of d, since all Base objects might not be Descendant
                IBibbleIn<Descendant> d = GetInBase();
            }
    
            static IBibbleOut<Descendant> GetOutDescendant()
            {
                return null;
            }
    
            static IBibbleIn<Base> GetInBase()
            {
                return null;
            }
        }
    }
