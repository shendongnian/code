      public class TestClass
      { }
    
      public struct TestStruct
      { }
      
      public enum TestEnum
      {
        e1,    
        e2,
        e3
      }
    
      public static class TestEnumConstraintExtenssion
      {
    
        public static bool IsSet<TEnum>(this TEnum _this, TEnum flag)
          where TEnum : struct
        {
          return (((uint)Convert.ChangeType(_this, typeof(uint))) & ((uint)Convert.ChangeType(flag, typeof(uint)))) == ((uint)Convert.ChangeType(flag, typeof(uint)));
        }
        //public static TestClass ToTestClass(this string _this)
        //{
        //  // #generates compile error  (so no missuse)
        //  return EnumConstraint.TryParse<TestClass>(_this);
        //}
        
        //public static TestStruct ToTestStruct(this string _this)
        //{
        //  // #generates compile error  (so no missuse)
        //  return EnumConstraint.TryParse<TestStruct>(_this);
        //}
        
        public static TestEnum ToTestEnum(this string _this)
        {
          // #enum type works just fine (coding constraint to Enum type)
          return EnumConstraint.TryParse<TestEnum>(_this);
        }
    
        public static void TestAll()
        {
          TestEnum t1 = "e3".ToTestEnum();
          TestEnum t2 = "e2".ToTestEnum();
          TestEnum t3 = "non existing".ToTestEnum(); // default(TestEnum) for non existing 
    
          bool b1 = t3.IsSet(TestEnum.e1); // you can ommit type
          bool b2 = t3.IsSet<TestEnum>(TestEnum.e2); // you can specify explicite type
    
          TestStruct t;
          // #generates compile error (so no missuse)
          //bool b3 = t.IsSet<TestEnum>(TestEnum.e1);
          
        }
    
      }
