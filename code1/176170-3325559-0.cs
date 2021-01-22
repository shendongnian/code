       [TestClass]
       public class UnitTest1 {
          class MyInt {
             public MyInt(int value) {
                _value = value;
             }
             int _value;
             public override int GetHashCode() {
                return _value;
             }
             public override bool Equals(object obj) {
                MyInt other = obj as MyInt;
                if (other != null)
                   return other._value == this._value;
                return false;
             }
          }
    
          [TestMethod]
          public void TestMethod1() {
             List<MyInt> list1 = new List<MyInt> {
                new MyInt(1),
                new MyInt(2),
             };
    
             List<MyInt> list2 = new List<MyInt> {
                new MyInt(2),
                new MyInt(3),
             };
    
             MyInt removed = list1[1];
             var result = list1.Except(list2);
             Assert.AreEqual(1, result.Count());
             Assert.IsFalse(result.Contains(removed));
          }
       }
