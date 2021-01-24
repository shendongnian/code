      enum myEnum {
        a = 0101,
        b = 2002,
        c = 0303
      }
    
      static class myEnumExtensions {
        public static string ToReport(this myEnum value) {
          return ((int)value).ToString("d4"); // 4 digits, i.e. "101" -> "0101"
        }
      }
    
      ...
    
      myEnum test = myEnum.a;
     
      Console.Write(test.ToReport());
 
