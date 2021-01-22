    public class MyType
    {
      public MyType(string s)
      {
        Property = s;
      }
      public string Property { get; set; }
    }
    public static class MyTypeExtensions
    {
      public static object GetTestInstance(this Type t)
      {
        var ctorInjectedDependency = "blah";
        var ctorInfo = t.GetConstructor(new[]{typeof(string)});
        return ctorInfo.Invoke(new object[] {ctorInjectedDependency});
      }
      public static T GetTestInstance<T>(this Type t)
      {
        var ctorInjectedDependency = "blah";
        var ctorInfo = t.GetConstructor(new[] { typeof(string) });
        return (T)ctorInfo.Invoke(new object[] { ctorInjectedDependency });
      }
    }
