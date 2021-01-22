    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    namespace ConsoleApplication18
    {
        public class XmlDocumentationStringSet : IEnumerable<string>
        {
            private HashSet<string> stringSet = new HashSet<string>(StringComparer.Ordinal);
            public XmlDocumentationStringSet(Assembly assembly)
            {
                AddRange(assembly.GetExportedTypes());
            }
            public bool Contains(string name)
            {
                return stringSet.Contains(name);
            }
            /// <summary>
            /// Heelloasdasdasd
            /// </summary>
            /// <param name="types"></param>
            public void AddRange(IEnumerable<Type> types)
            {
                foreach (var type in types)
                {
                    Add(type);
                }
            }
            public void Add(Type type)
            {
                // Public API only
                if (!type.IsVisible)
                {
                    return;
                }
                var members = type.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (var member in members)
                {
                    Add(type, member);
                }
            }
        
            StringBuilder sb = new StringBuilder();
            private void Add(Type type, MemberInfo member)
            {
                Type nestedType = null;
            
                sb.Length = 0;
                switch (member.MemberType)
                {
                    case MemberTypes.Constructor:
                        sb.Append("M:");
                        AppendConstructor(sb, (ConstructorInfo)member);
                        break;
                    case MemberTypes.Event:
                        sb.Append("E:");
                        AppendEvent(sb, (EventInfo)member);
                        break;
                    case MemberTypes.Field:
                        sb.Append("F:");
                        AppendField(sb, (FieldInfo)member);
                        break;
                    case MemberTypes.Method:
                        sb.Append("M:");
                        AppendMethod(sb, (MethodInfo)member);
                        break;
                    case MemberTypes.NestedType:
                        nestedType = (Type)member;
                        if (IsVisible(nestedType))
                        {
                            sb.Append("T:");
                            AppendNestedType(sb, (Type)member);
                        }
                        break;
                    case MemberTypes.Property:
                        sb.Append("P:");
                        AppendProperty(sb, (PropertyInfo)member);
                        break;
                }
            
                if (sb.Length > 0)
                {
                    stringSet.Add(sb.ToString());
                }
                if (nestedType != null)
                {
                    Add(nestedType);
                }
            }
            private bool IsVisible(Type nestedType)
            {
                return nestedType.IsVisible;
            }
            private void AppendProperty(StringBuilder sb, PropertyInfo propertyInfo)
            {
                if (!IsVisible(propertyInfo))
                {
                    sb.Length = 0;
                    return;
                }
                AppendType(sb, propertyInfo.DeclaringType);
                sb.Append('.').Append(propertyInfo.Name);
            }
            private bool IsVisible(PropertyInfo propertyInfo)
            {
                var getter = propertyInfo.GetGetMethod();
                var setter = propertyInfo.GetSetMethod();
                return (getter != null && IsVisible(getter)) || (setter != null && IsVisible(setter));
            }
            private void AppendNestedType(StringBuilder sb, Type type)
            {
                AppendType(sb, type.DeclaringType);
            }
            private void AppendMethod(StringBuilder sb, MethodInfo methodInfo)
            {
                if (!IsVisible(methodInfo) || (methodInfo.IsHideBySig && methodInfo.IsSpecialName))
                {
                    sb.Length = 0;
                    return;
                }
                AppendType(sb, methodInfo.DeclaringType);
                sb.Append('.').Append(methodInfo.Name);
                AppendParameters(sb, methodInfo.GetParameters());
            }
            private bool IsVisible(MethodInfo methodInfo)
            {
                return methodInfo.IsFamily || methodInfo.IsPublic;
            }
            private void AppendParameters(StringBuilder sb, ParameterInfo[] parameterInfo)
            {
                if (parameterInfo.Length == 0)
                {
                    return;
                }
                sb.Append('(');
                for (int i = 0; i < parameterInfo.Length; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(',');
                    }
                    var p = parameterInfo[i];
                    AppendType(sb, p.ParameterType);
                }
                sb.Append(')');
            }
            private void AppendField(StringBuilder sb, FieldInfo fieldInfo)
            {
                if (!IsVisible(fieldInfo))
                {
                    sb.Length = 0;
                    return;
                }
                AppendType(sb, fieldInfo.DeclaringType);
                sb.Append('.').Append(fieldInfo.Name);
            }
            private bool IsVisible(FieldInfo fieldInfo)
            {
                return fieldInfo.IsFamily || fieldInfo.IsPublic;
            }
            private void AppendEvent(StringBuilder sb, EventInfo eventInfo)
            {
                if (!IsVisible(eventInfo))
                {
                    sb.Length = 0;
                    return;
                }
                AppendType(sb, eventInfo.DeclaringType);
                sb.Append('.').Append(eventInfo.Name);
            }
            private bool IsVisible(EventInfo eventInfo)
            {
                return true; // hu?
            }
            private void AppendConstructor(StringBuilder sb, ConstructorInfo constructorInfo)
            {
                if (!IsVisible(constructorInfo))
                {
                    sb.Length = 0;
                    return;
                }
                AppendType(sb, constructorInfo.DeclaringType);
                sb.Append('.').Append("#ctor");
                AppendParameters(sb, constructorInfo.GetParameters());
            }
            private bool IsVisible(ConstructorInfo constructorInfo)
            {
                return constructorInfo.IsFamily || constructorInfo.IsPublic;
            }
            private void AppendType(StringBuilder sb, Type type)
            {
                if (type.DeclaringType != null)
                {
                    AppendType(sb, type.DeclaringType);
                    sb.Append('.');
                }
                else if (!string.IsNullOrEmpty(type.Namespace))
                {
                    sb.Append(type.Namespace);
                    sb.Append('.');
                }
                sb.Append(type.Name);
                if (type.IsGenericType && !type.IsGenericTypeDefinition)
                {
                    // Remove "`1" suffix from type name
                    while (char.IsDigit(sb[sb.Length - 1]))
                        sb.Length--;
                    sb.Length--;
                    {
                        var args = type.GetGenericArguments();
                        sb.Append('{');
                        for (int i = 0; i < args.Length; i++)
                        {
                            if (i > 0)
                            {
                                sb.Append(',');
                            }
                            AppendType(sb, args[i]);
                        }
                        sb.Append('}');
                    }
                }
            }
            public IEnumerator<string> GetEnumerator()
            {
                return stringSet.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
