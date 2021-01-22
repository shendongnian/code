    using System.Reflection; // or Mono.Reflection
    public static class MyClass{
        private static string myString;
    }
    var newValue = "Potatoes";            
    var field = typeof(MyClass).GetField("myString", BindingFlags.Static | BindingFlags.NonPublic);
    field.SetValue(null, newValue); // the first null is because the class is static, the second is the new value
