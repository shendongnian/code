    using System;
    using System.Collections;
    using System.Reflection;
    using System.Text;
    public class ObjectDumper
    {
        private int _level;
        private readonly int _indentSize;        
        private readonly StringBuilder _stringBuilder;
        private ObjectDumper(int indentSize)
        {
            _indentSize = indentSize;
            _stringBuilder = new StringBuilder();
        }
        public static string Dump(object element)
        {
            return Dump(element, 2);
        }
        public static string Dump(object element, int indentSize)
        {
            var instance = new ObjectDumper(indentSize);
            return instance.DumpElement(element);
        }
        private string DumpElement(object element)
        {
            if (element == null || element is ValueType || element is string)
            {
                Write(FormatValue(element));
            }
            else
            {
                var objectType = element.GetType();
                if (!typeof (IEnumerable).IsAssignableFrom(objectType))
                {
                    Write("{{{0}}}", objectType.FullName);
                    _level++;
                }
                var enumerableElement = element as IEnumerable;
                if (enumerableElement != null)
                {
                    foreach (object item in enumerableElement)
                    {
                        if (item is IEnumerable && !(item is string))
                        {
                            _level++;
                            DumpElement(item);
                            _level--;
                        }
                        else
                        {
                            DumpElement(item);
                        }
                    }
                }
                else
                {
                    MemberInfo[] members = element.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var memberInfo in members)
                    {
                        var fieldInfo = memberInfo as FieldInfo;
                        var propertyInfo = memberInfo as PropertyInfo;
                        if (fieldInfo == null && propertyInfo == null)
                            continue;
                        var type = fieldInfo != null ? fieldInfo.FieldType : propertyInfo.PropertyType;
                        object value = fieldInfo != null
                                           ? fieldInfo.GetValue(element)
                                           : propertyInfo.GetValue(element, null);
                        if (type.IsValueType || type == typeof(string))
                        {
                            Write("{0}: {1}", memberInfo.Name, FormatValue(value));
                        }
                        else
                        {
                            Write("{0}: {1}", memberInfo.Name, typeof(IEnumerable).IsAssignableFrom(type) ? "..." : "{ }");
                            _level++;
                            DumpElement(value);
                            _level--;
                        }
                    }                    
                }
                if (!typeof(IEnumerable).IsAssignableFrom(objectType))
                {
                    _level--;
                }
            }
            return _stringBuilder.ToString();
        }
        private void Write(string value, params object[] args)
        {
            var space = new string(' ', _level * _indentSize);
            if (args != null)
                value = string.Format(value, args);
            _stringBuilder.AppendLine(space + value);
        }
        private string FormatValue(object o)
        {
            if (o == null)
                return ("null");
            if (o is DateTime)
                return (((DateTime)o).ToShortDateString());
            if (o is string)
                return string.Format("\"{0}\"", o);
            if (o is ValueType)
                return (o.ToString());
            if (o is IEnumerable)
                return ("...");
            return ("{ }");
        }
    }
