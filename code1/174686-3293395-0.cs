       [TestClass]
       public class UnitTest1 {
          private HashSet<char> _legalChars = new HashSet<char>("yYmMdDsShH".ToCharArray());
    
          public bool IsPossibleDateTimeFormat(string format) {
             if (string.IsNullOrEmpty(format))
                return false; // or whatever makes sense to you
             return !format.Except(_legalChars).Any();
          }
    
          [TestMethod]
          public void TestMethod1() {
             bool result = IsPossibleDateTimeFormat("yydD");
             result = IsPossibleDateTimeFormat("abc");
          }
       }
