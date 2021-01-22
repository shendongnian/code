    //Old and busted
    public abstract class Enum
    {
      public static object Parse(Type enumType, string value);
    }
    //To call it:
    MyEnum x = (MyEnum) Enum.Parse(typeof(MyEnum), someString);
----------
    
    //New and groovy
    public abstract class Enum
    {
      public static T Parse<T>(string value);
    }
    
    //To call it:
    MyEnum x = Enum.Parse<MyEnum>(someString);
