    public class MyBoolAttribute: Attribute
    {
            public MyBoolAttribute(bool val)
            {
                Passed = val;
            }
    
            public bool Passed
            {
                get;
                set;
            }
    }
    public enum MyEnum
    {
            [MyBoolAttribute(true)]
            Passed,
            [MyBoolAttribute(false)]
            Failed,
            [MyBoolAttribute(true)]
            PassedUnderCertainCondition,
            ... and other enum values
            
    }
    /* the extension method */    
    public static bool DidPass(this Enum en)
    {
           MyBoolAttribute attrib = GetAttribute<MyBoolAttribute>(en);
           return attrib.Passed;
    }
    
    /* general helper method to get attributes of enums */
    public static T GetAttribute<T>(Enum en) where T : Attribute
    {
           Type type = en.GetType();
           MemberInfo[] memInfo = type.GetMember(en.ToString());
           if (memInfo != null && memInfo.Length > 0)
           {
                 object[] attrs = memInfo[0].GetCustomAttributes(typeof(T),
                 false);
        
                 if (attrs != null && attrs.Length > 0)
                    return ((T)attrs[0]);
        
           }
           return null;
    }
