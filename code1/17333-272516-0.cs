    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    using System.Linq;
    using System.Data;
    
    
    namespace FieldAttribute
    {
        [global::System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
        sealed class DefaultValueAttribute : Attribute
        {
            public DefaultValueAttribute(int i)
            {
                IntVal = i;
            }
    
            public DefaultValueAttribute(bool b)
            {
                BoolVal = b;
            }
            public int IntVal { get; set; }
            public bool BoolVal { get; set; }
            private static FieldInfo[] GetAttributedFields(object o, string matchName)
            {
                Type t = o.GetType();
                FieldInfo[] fields = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                return fields.Where(fi => ((matchName != null && fi.Name == matchName) || matchName == null) &&
                                (fi.GetCustomAttributes(false).Where(attr => attr is DefaultValueAttribute)).Count() > 0).ToArray();
            }
            public static void SetDefaultFieldValues(object o)
            {
                FieldInfo[] fields = GetAttributedFields(o, null);
                foreach (FieldInfo fi in fields)
                {
                    IEnumerable<object> attrs = fi.GetCustomAttributes(false).Where(attr => attr is DefaultValueAttribute);
                    foreach (Attribute attr in attrs)
                    {
                        DefaultValueAttribute def = attr as DefaultValueAttribute;
                        Type fieldType = fi.FieldType;
                        if (fieldType == typeof(Boolean))
                        {
                            fi.SetValue(o, def.BoolVal);
                        }
                        if (fieldType == typeof(Int32))
                        {
                            fi.SetValue(o, def.IntVal);
                        }
                    }
                }
            }
            public static bool HasDefaultValue(object o, string fieldName)
            {
                FieldInfo[] fields = GetAttributedFields(o, null);
                foreach (FieldInfo fi in fields)
                {
                    IEnumerable<object> attrs = fi.GetCustomAttributes(false).Where(attr => attr is DefaultValueAttribute);
                    foreach (Attribute attr in attrs)
                    {
                        DefaultValueAttribute def = attr as DefaultValueAttribute;
                        Type fieldType = fi.FieldType;
                        if (fieldType == typeof(Boolean))
                        {
                            return (Boolean)fi.GetValue(o) == def.BoolVal;
                        }
                        if (fieldType == typeof(Int32))
                        {
                            return (Int32)fi.GetValue(o) == def.IntVal;
                        }
                    }
                }
                return false;
            }
        }
        class Program
        {
            [DefaultValue(3)]
            int foo;
            [DefaultValue(true)]
            bool b;
            public Program()
            {
                DefaultValueAttribute.SetDefaultFieldValues(this);
                Console.WriteLine(b + " " + foo);
                Console.WriteLine("b has default value? " + DefaultValueAttribute.HasDefaultValue(this, "b"));
                foo = 2;
                Console.WriteLine("foo has default value? " + DefaultValueAttribute.HasDefaultValue(this, "foo"));
            }
            static void Main(string[] args)
            {
                Program p = new Program();
            }
        }
    }
