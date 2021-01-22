    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    namespace TestDeepClone
    {
        class Program
        {
            static void Main(string[] args)
            {
                A a = new A();
                a.name = "main_A";
                a.b_list.Add(new B(a) { name = "b1" });
                a.b_list.Add(new B(a) { name = "b2" });
                A a2 = (A)a.DeepClone();
                a2.name = "second_A";
                // Perform re-parenting manually after deep copy.
                foreach( var b in a2.b_list )
                    b.parent = a2;
                Debug.WriteLine("ok");
            }
        }
        public class A
        {
            public String name = "one";
            public List<String> list = new List<string>();
            public List<String> null_list;
            public List<B> b_list = new List<B>();
            private int private_pleaseCopyMeAsWell = 5;
            public override string ToString()
            {
                return "A(" + name + ")";
            }
        }
        public class B
        {
            public B() { }
            public B(A _parent) { parent = _parent; }
            public A parent;
            public String name = "two";
        }
        public static class ReflectionEx
        {
            public static Type GetUnderlyingType(this MemberInfo member)
            {
                Type type;
                switch (member.MemberType)
                {
                    case MemberTypes.Field:
                        type = ((FieldInfo)member).FieldType;
                        break;
                    case MemberTypes.Property:
                        type = ((PropertyInfo)member).PropertyType;
                        break;
                    case MemberTypes.Event:
                        type = ((EventInfo)member).EventHandlerType;
                        break;
                    default:
                        throw new ArgumentException("member must be if type FieldInfo, PropertyInfo or EventInfo", "member");
                }
                return Nullable.GetUnderlyingType(type) ?? type;
            }
            /// <summary>
            /// Gets fields and properties into one array.
            /// Order of properties / fields will be preserved in order of appearance in class / struct. (MetadataToken is used for sorting such cases)
            /// </summary>
            /// <param name="type">Type from which to get</param>
            /// <returns>array of fields and properties</returns>
            public static MemberInfo[] GetFieldsAndProperties(this Type type)
            {
                List<MemberInfo> fps = new List<MemberInfo>();
                fps.AddRange(type.GetFields());
                fps.AddRange(type.GetProperties());
                fps = fps.OrderBy(x => x.MetadataToken).ToList();
                return fps.ToArray();
            }
            public static object GetValue(this MemberInfo member, object target)
            {
                if (member is PropertyInfo)
                {
                    return (member as PropertyInfo).GetValue(target, null);
                }
                else if (member is FieldInfo)
                {
                    return (member as FieldInfo).GetValue(target);
                }
                else
                {
                    throw new Exception("member must be either PropertyInfo or FieldInfo");
                }
            }
            public static void SetValue(this MemberInfo member, object target, object value)
            {
                if (member is PropertyInfo)
                {
                    (member as PropertyInfo).SetValue(target, value, null);
                }
                else if (member is FieldInfo)
                {
                    (member as FieldInfo).SetValue(target, value);
                }
                else
                {
                    throw new Exception("destinationMember must be either PropertyInfo or FieldInfo");
                }
            }
            /// <summary>
            /// Deep clones specific object.
            /// Analogue can be found here: http://stackoverflow.com/questions/129389/how-do-you-do-a-deep-copy-an-object-in-net-c-specifically
            /// This is now improved version (list support added)
            /// </summary>
            /// <param name="obj">object to be cloned</param>
            /// <returns>full copy of object.</returns>
            public static object DeepClone(this object obj)
            {
                if (obj == null)
                    return null;
                Type type = obj.GetType();
                if (obj is IList)
                {
                    IList list = ((IList)obj);
                    IList newlist = (IList)Activator.CreateInstance(obj.GetType(), list.Count);
                    foreach (object elem in list)
                        newlist.Add(DeepClone(elem));
                    return newlist;
                } //if
                if (type.IsValueType || type == typeof(string))
                {
                    return obj;
                }
                else if (type.IsArray)
                {
                    Type elementType = Type.GetType(type.FullName.Replace("[]", string.Empty));
                    var array = obj as Array;
                    Array copied = Array.CreateInstance(elementType, array.Length);
                    for (int i = 0; i < array.Length; i++)
                        copied.SetValue(DeepClone(array.GetValue(i)), i);
                    return Convert.ChangeType(copied, obj.GetType());
                }
                else if (type.IsClass)
                {
                    object toret = Activator.CreateInstance(obj.GetType());
                    MemberInfo[] fields = type.GetFieldsAndProperties();
                    foreach (MemberInfo field in fields)
                    {
                        // Don't clone parent back-reference classes. (Using special kind of naming 'parent' 
                        // to indicate child's parent class.
                        if (field.Name == "parent")
                        {
                            continue;
                        }
                        object fieldValue = field.GetValue(obj);
                        if (fieldValue == null)
                            continue;
                        field.SetValue(toret, DeepClone(fieldValue));
                    }
                    return toret;
                }
                else
                {
                    // Don't know that type, don't know how to clone it.
                    if (Debugger.IsAttached)
                        Debugger.Break();
                    return null;
                }
            } //DeepClone
        }
    }
