    public interface Test<T>
        where T : System.Runtime.Serialization.ISerializable
    {
        T method();
    }
    public class TestObject : System.Runtime.Serialization.ISerializable
    {
        #region ISerializable Membres
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    public class TestClass : Test<TestObject>
    {
        #region Test<TestObject> Membres
        public TestObject method()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
