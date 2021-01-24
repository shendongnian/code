    public class SomeClass<Derived>
        where Derived : class
    {
        public void call<Parent, NewDerived>()
            where Parent : class
            where NewDerived: Derived, Parent
        {
            ParentChecker<NewDerived, Parent> checker =
            new ParentChecker<NewDerived, Parent>();
        }
    }
