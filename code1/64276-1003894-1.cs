    [Serializable]
    public class TestClass
    {
         private ICustomInterface _iCustomInterfaceObject;
         
         public ICustomInterface CustomInterfaceProperty
         {
             get { return _iCustomInterfaceObject; }
             set { _iCustomInterfaceObject = value; }
         }
    }
