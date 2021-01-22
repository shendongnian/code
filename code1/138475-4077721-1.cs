    public class MySuperClass
    {
        private IDependencyClass1 mDependency1;
        private IDependencyClass2 mDependency2;
        public MySuperClass(IDependencyClass1 dep1, IDependencyClass2 dep2)
        {
            mDependency1 = dep1;
            mDependency2 = dep2;
        }
        private void MySuperMethodThatDoesSomethingComplex()
        {
            string s = mDependency1.GetMessage();
            mDependency2.PrintMessage(s);
        }
    }
