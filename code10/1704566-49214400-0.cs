    public class SomeClass<Parent> //instead of derived
        where Parent : class
    {
        public void call<Derived>()
            where Derived : class, Parent
        {
            ParentChecker<Derived, Parent> checker =  new ParentChecker<Derived, Parent>();
        }
    }
