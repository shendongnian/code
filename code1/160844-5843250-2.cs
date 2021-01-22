    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Reflection;
    
    namespace Utils
    {
       public class StaticMembersDynamicWrapper : DynamicObject
       {
          private Type _type;
    
          public StaticMembersDynamicWrapper(Type type) { _type = type; }
    
          // Handle static methods
          public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
          {
             var methods = _type
                .GetMethods(BindingFlags.FlattenHierarchy | BindingFlags.Static | BindingFlags.Public)
                .Where(methodInfo => methodInfo.Name == binder.Name);
             
             var method = methods.FirstOrDefault();
             if (method != null)
             {
                result = method.Invoke(null, args);
                return true;
             }
    
             result = null;
             return false;
          }
       }
    
       public static class StaticMembersDynamicWrapperExtensions
       {
          static Dictionary<Type, DynamicObject> cache =
             new Dictionary<Type, DynamicObject>
             {
                {typeof(double), new StaticMembersDynamicWrapper(typeof(double))},
                {typeof(float), new StaticMembersDynamicWrapper(typeof(float))},
                {typeof(uint), new StaticMembersDynamicWrapper(typeof(uint))},
                {typeof(int), new StaticMembersDynamicWrapper(typeof(int))},
                {typeof(sbyte), new StaticMembersDynamicWrapper(typeof(sbyte))}
             };
    
          /// <summary>
          /// Allows access to static fields, properties, and methods, resolved at run-time.
          /// </summary>
          public static dynamic StaticMembers(this Type type)
          {
             DynamicObject retVal;
             if (!cache.TryGetValue(type, out retVal))
                return new StaticMembersDynamicWrapper(type);
    
             return retVal;
          }
       }
    }
