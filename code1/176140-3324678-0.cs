       [TestClass]
       public class UnitTest1 {
          class DerivedA {
             public static implicit operator DerivedA(DerivedB b) {
                return new DerivedA();
             }
          }
          class DerivedB {
             public static implicit operator DerivedB(DerivedA a) {
                return new DerivedB();
             }
          }
    
          [TestMethod]
          public void TestMethod1() {
             IList<DerivedA> lista = new List<DerivedA> {
                new DerivedA()
             };
             var casted = lista.Cast<DerivedB>();
    
             try {
                DerivedB b = casted.First();
                Assert.Fail();
             } catch (InvalidCastException) {
                // exception will be thrown
             }
          }
       }
