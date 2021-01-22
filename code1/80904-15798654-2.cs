    public interface IClassA
    {
        void Foo1();
        void Foo2();
    }
    public interface IClassB
    {
        void Foo3();
        void Foo4();
    }
    public class ClassA :IClassA
    {
        #region IClassA Members
        public void Foo1()
        {
        }
        public void Foo2()
        {
        }
        #endregion
    }
    public class ClassB :IClassB
    {
        #region IClassB Members
        public void Foo3()
        {
        }
        public void Foo4()
        {
        }
        #endregion
    }
    public class MultipleInheritance :IClassA, IClassB
    {
        private IClassA _classA;
        private IClassB _classB;
        public MultipleInheritance(IClassA classA, IClassB classB)
        {
            _classA = classA;
            _classB = classB;
        }
        public void Foo1()
        {
            _classA.Foo1();
        }
        public void Foo2()
        {
            _classA.Foo2();
            AddedBehavior1();
        }
        public void Foo3()
        {
            _classB.Foo3();
            AddedBehavior2();
        }
        public void Foo4()
        {
            _classB.Foo4();
        }
        private void AddedBehavior1()
        {
        }
        private void AddedBehavior2()
        {
        }
    }
