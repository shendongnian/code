    /// <summary>
    /// Dummy interface
    /// </summary>
    public interface ITest1
    { }
    /// <summary>
    /// Dummy interface
    /// </summary>
    public interface ITest2
    { }
    /// <summary>
    /// Generic Class
    /// </summary>
    public class GenericClass
    {
        /// <summary>
        /// First overload
        /// </summary>
        /// <param name="test1"></param>
        public void TestMethod(ITest1 test1)
        { }
        /// <summary>
        /// Second overload
        /// </summary>
        /// <param name="test2"></param>
        public void TestMethod(ITest2 test2)
        { }
        public void ConditionallyCallTest(ITest1 test, bool someLogic)
        {
            if(Common(someLogic))
                return;
            TestMethod(test);
        }
        public void ConditionallyCallTest(ITest2 test, bool someLogic)
        {
            if(Common(someLogic))
                return;
            TestMethod(test);
        }
        private bool Common(bool someLogic)
        {
            if (someLogic)
            {
                return false;
            }
            // .. Perform Common operations here
            return true;
        }
    }
