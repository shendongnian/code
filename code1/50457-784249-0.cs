    public static class MyGlobals
    {
       public static readonly List<MyEnum> EnumList = 
           Enum.GetValues(typeof(MyEnum)).Cast<MyEnum>().ToList();
    }
