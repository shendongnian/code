    static void Main(string[] args)
    {
            Mock<ITest> mock = new Mock<ITest>();
        
            ClassBeingTested testedClass = new ClassBeingTested();
            testedClass.WorkMethod(mock.Object);
            mock.Verify(m => m.MethodToCheckIfCalled());
    }
    class ClassBeingTested
    {
        public void WorkMethod(ITest test)
        {
            //test.MethodToCheckIfCalled();
        }
    }
    public interface ITest
    {
        void MethodToCheckIfCalled();
    }
