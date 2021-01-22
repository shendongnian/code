    // apply this attribute to any properties or fields that you want added to the attributes dictionary
    [AttributeUsage(
        AttributeTargets.Property |
        AttributeTargets.Field |
        AttributeTargets.Class |
        AttributeTargets.Struct |
        AttributeTargets.Interface,
        AllowMultiple = true, Inherited = true)]
    public class InspectAttribute : Attribute
    {
        // optionally specify the member name explicitly, for use on classes, structs, and interfaces
        public string MemberName { get; set; }
        public InspectAttribute() { }
        public InspectAttribute(string memberName)
        {
            this.MemberName = memberName;
        }
    }
    public class Inspector<T>
    {
        // Inspector is a generic class, therefore there will be a separate instance of the _InspectActions variable per type
        private static List<Action<Dictionary<string, string>, T>> _InspectActions;
        static Inspector()
        {
            _InspectActions = new List<Action<Dictionary<string, string>, T>>();
            foreach (MemberInfo m in GetInspectableMembers(typeof(T)))
            {
                switch (m.MemberType)
                {
                    case MemberTypes.Property:
                        {
                            // declare a separate variable for variable scope with anonymous delegate
                            PropertyInfo member = m as PropertyInfo;
                            // create an action delegate to add an entry to the attributes dictionary using the property name and value
                            _InspectActions.Add(
                                delegate(Dictionary<string, string> attributes, T item)
                                {
                                    object value = member.GetValue(item, null);
                                    attributes.Add(member.Name, (value == null) ? "[null]" : value.ToString());
                                });
                        }
                        break;
                    case MemberTypes.Field:
                        {
                            // declare a separate variable for variable scope with anonymous delegate
                            FieldInfo member = m as FieldInfo;
                            // need to create a separate variable so that delegates do not share the same variable
                            // create an action delegate to add an entry to the attributes dictionary using the field name and value
                            _InspectActions.Add(
                                delegate(Dictionary<string, string> attributes, T item)
                                {
                                    object value = member.GetValue(item);
                                    attributes.Add(member.Name, (value == null) ? "[null]" : value.ToString());
                                });
                        }
                        break;
                    default:
                        // for all other member types, do nothing
                        break;
                }
            }
        }
        private static IEnumerable<MemberInfo> GetInspectableMembers(Type t)
        {
            // get all instance fields and properties
            foreach (MemberInfo member in t.GetMembers(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.GetField | BindingFlags.GetProperty))
            {
                // check if the current member is decorated with an Inspect attribute
                object[] inspectAttributes = member.GetCustomAttributes(typeof(InspectAttribute), true);
                if (inspectAttributes != null && inspectAttributes.Length > 0)
                {
                    yield return member;
                }
            }
            // now look for any Inspect attributes defined at the type level
            InspectAttribute[] typeLevelInspectAttributes = (InspectAttribute[])t.GetCustomAttributes(typeof(InspectAttribute), true);
            if (typeLevelInspectAttributes != null && typeLevelInspectAttributes.Length > 0)
            {
                foreach (InspectAttribute attribute in typeLevelInspectAttributes)
                {
                    // search for members matching the name provided by the Inspect attribute
                    MemberInfo[] members = t.GetMember(attribute.MemberName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy);
                    if (members != null && members.Length > 0)
                    {
                        foreach (MemberInfo member in members)
                        {
                            yield return member;
                        }
                    }
                }
            }
        }
        public static Dictionary<string, string> Inspect(T item)
        {
            // create a new attributes dictionary
            Dictionary<string, string> attributes = new Dictionary<string, string>();
            foreach (Action<Dictionary<string, string>, T> inspectAction in _InspectActions)
            {
                // execute each "inspect" action.
                // This will execute the delegates we created earlier, causing entries to be added to the dictionary
                inspectAction(attributes, item);
            }
            return attributes;
        }
    }
    public class BasePage
    {
        public int? SomeValue { get; set; }
    }
    // example class with properties decorated with the Inspect attribute
    [Inspect("SomeValue")] // also inspect the "SomeValue" property from the BasePage class
    public class MyPage : BasePage
    {
        [Inspect]
        public int? MaxLength { get; set; }
        [Inspect]
        public int? Size { get; set; }
        [Inspect]
        public int? Width { get; set; }
        [Inspect]
        public int? Height { get; set; }
        public string GenerateAttributeString()
        {
            System.Text.StringBuilder attributes = new System.Text.StringBuilder();
            foreach (KeyValuePair<string, string> item in Inspector<MyPage>.Inspect(this))
            {
                attributes.Append(item.Key + "=\"" + item.Value + "\" ");
            }
            return attributes.ToString();
        }
    }
