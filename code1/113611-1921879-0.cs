    namespace TestDll
    {
        [Guid("FB8AB9B9-6986-4130-BD74-4439776D1A3D")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [ComVisible(true)]
        public interface IClass1
        {
            [DispId(50)]
            void DisplayMessage();
        }
    
    
       [Guid("74201338-6927-421d-A095-3BE4FD1EF0B4")]
       [ClassInterface(ClassInterfaceType.None)]
       [ComVisible(true)]
       [ProgId("TestDll.Class1")]
        public class Class1:IClass1
        {              
            void IClass1.DisplayMessage()
            { 
                MessageBox.Show ("Displyaing message");
            }
    
        }
    }
