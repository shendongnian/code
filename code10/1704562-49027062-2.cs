    public class SomeClass<Derived>
        where Derived : class
    {
        public void call<Parent, NewDerived>()
            where Parent : class
            where NewDerived: Derived, Parent
        {
            ParenthoodChecker<NewDerived, Parent> checker =
                new ParenthoodChecker<NewDerived, Parent>();
        }
    }
