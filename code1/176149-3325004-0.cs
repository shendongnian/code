       [TestClass]
       public class UnitTest1 {
          class A {
             public void DoWork() {
                B b = new B();
                b.GetData = () => "Some data";
                b.DoBWork();
             }
          }
          class B {
             public Func<string> GetData { get; set; }
             public void DoBWork() {
                string data = GetData();
                Console.WriteLine("Working with {0}", data);
             }
          }
    
          [TestMethod]
          public void TestMethod1() {
             A a = new A();
             a.DoWork();
          }
       }
