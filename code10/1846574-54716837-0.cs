    using System.Diagnostics;
    
    namespace ConsoleApp4
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Arrange
                var stub = new StubOfMyInterface();
    
                // Act
                var sut = new SystemUnderTest(stub);
                var result = sut.Run(5);
    
                // Assert
                Trace.Assert(result == 5);
            }
        }
    
        public delegate void MyDelegate(int i);
    
        public interface MyInterface
        {
            void Method(int i);
    
            MyDelegate MyDelegate { set; }
        }
    
        public class StubOfMyInterface : MyInterface
        {
            public void Method(int i)
            {
                MyDelegate?.Invoke(i);
            }
    
            public MyDelegate MyDelegate { get; set; }
        }
    
        class SystemUnderTest
        {
            int i = 0;
    
            readonly MyInterface myInterface;
    
            public SystemUnderTest(MyInterface myInterface)
            {
                this.myInterface = myInterface;
                this.myInterface.MyDelegate = DelegateHandler;
            }
    
            public int Run(int input)
            {
                this.myInterface.Method(input);
                return i;
            }
    
            void DelegateHandler(int i)
            {
                this.i = i;
            }
        }   
    }
    
