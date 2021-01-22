    static void Main(string[] args)
    {
            Mock<ITest> mock = new Mock<ITest>();
            mock.Expect(m => m.MethodToCheckIfCalled())
                .Verifiable();
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
