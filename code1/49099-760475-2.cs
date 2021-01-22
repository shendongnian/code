    using System.Reflection;
    
    namespace Dynamo
    {
      public abstract class DynamicBase
      {
        public bool EvaluateCondition(string methodName, params object[] p)
        {
          methodName = string.Format("__dm_{0}", methodName);
          BindingFlags flags = BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic;
          return (bool)GetType().InvokeMember(methodName, flags, null, this, p);
        }
        public object InvokeMethod(string methodName, params object[] p)
        {
          BindingFlags flags = BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic;
          return GetType().InvokeMember(methodName, flags, null, this, p);
        }
        public double Transform(string functionName, params object[] p)
        {
          functionName = string.Format("__dm_{0}", functionName);
          BindingFlags flags = BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic;
          return (double)GetType().InvokeMember(functionName, flags, null, this, p);
        }
      }
    }
