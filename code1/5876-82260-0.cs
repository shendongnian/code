    [Serializable]
    public class MyClass
    {
       public Exception TheException; // serializable
    }
    
    public class MyNonSerializableException : Exception
    {
    ...
    }
    
    ...
    MyClass myClass = new MyClass();
    myClass.TheException = new MyNonSerializableException();
    // myClass now has a non-serializable member
