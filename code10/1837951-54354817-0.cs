    public interface IStringToLong {
       long StringToLong(string val);
    }
    public class StringToLong : IStringToLong {
       public long StringToLong(string val) => Convert.ToInt64(val); 
    }
    // While using dependency injection
    public class SomeClass {
       private readonly IStringToLong _stringToLong;
       public SomeClass(IStringToLong stringToLong) {
          _stringToLong = stringToLong;
       }
       
       public void SomeMethod {
           // Instead of Convert.ToInt64("10000"), use this:
           var someLong = _stringToLong.StringToLong("10000");
       }
    }
