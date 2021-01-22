    public interface IMyApi
    {
        IList<int> GetReadOnlyValues();
    }
    
    public class MyApiImplementation : IMyApi
    {
        public IList<int> GetReadOnlyValues()
        {
            List<int> myList = new List<int>();
            ... populate list
            return myList.AsReadOnly();
        }
    }
    public class MyMockApiImplementationForUnitTests : IMyApi
    {
        public IList<int> GetReadOnlyValues()
        {
            IList<int> testValues = new int[] { 1, 2, 3 };
            return testValues;
        }
    }
