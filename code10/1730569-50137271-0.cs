    [TestClass]
    public class Method_Tetsts
    {
        class Device { }
        class Mouse : Device { }
    
        [TestMethod]
        public void ActionTest()
        {
    
            void DeviceAction<T>( T target)
            {  
                Assert.AreEqual(target.GetType().Name, "Mouse");
            }
    
            Action<Device> b = DeviceAction;
            Action<Mouse> d = b; // Error cannot implicitly convert type CSharpTests.Program.Action<CSharpTests.Device> to CSharpTests.Program.Action<CSharpTests.Mouse>
            d(new Mouse());
        }
    }
