    public class SomeClass<Derived> 
        where Derived : class
    {
        public void call<Parent>()
            where Parent : class
        {
            if(typeof(Derived).IsSubclassOf(typeof(Parent)))
            {
                //do your stuff
            }
            else
            {
                throw new Exception("Must be called wih parent classes only!");
            }
        }
    }
