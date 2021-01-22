    using System;
    using System.Web;
    using System.Reflection;
    public class TestClass {
        public static void TestPreStartInitMethodLocation(Assembly assembly) {
            var attributes = (PreApplicationStartMethodAttribute[])assembly.GetCustomAttributes(typeof(PreApplicationStartMethodAttribute), inherit: true);
            if (attributes != null && attributes.Length != 0) {
                PreApplicationStartMethodAttribute attribute = attributes[0];
                MethodInfo method = null;
                // They must be in the same assembly!
                if (attribute.Type != null && !String.IsNullOrEmpty(attribute.MethodName) && attribute.Type.Assembly == assembly) {
                    method = FindPreStartInitMethod(attribute.Type, attribute.MethodName);
                }
                if (method == null) {
                    throw new HttpException("Couldn't find attribute");
                }
            }
        }
        public static MethodInfo FindPreStartInitMethod(Type type, string methodName) {
            MethodInfo method = null;
            if (type.IsPublic) {
                method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase,
                                binder: null,
                                types: Type.EmptyTypes,
                                modifiers: null);
            }
            return method;
        }
    }
