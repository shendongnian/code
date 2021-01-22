       [TestClass]
       public class UnitTest1 {
          class MyString {
             public MyString(string value) {
                _value = value;
             }
             string _value;
             public override int GetHashCode() {
                return _value.GetHashCode();
             }
             public override bool Equals(object obj) {
                MyString other = obj as MyString;
                if (other != null)
                   return other._value == this._value;
                return false;
             }
          }
    
          [TestMethod]
          public void TestMethod1() {
             List<MyString> list1 = new List<MyString> {
                new MyString("1"),
                new MyString("2"),
             };
    
             List<MyString> list2 = new List<MyString> {
                new MyString("2"),
                new MyString("3"),
             };
    
             MyString removed = list1[1];
             var result = list1.Except(list2);
             Assert.AreEqual(1, result.Count());
             Assert.IsFalse(result.Contains(removed));
          }
       }
