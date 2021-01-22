    MyObject obj = new MyObject();
    bool hasIt = obj.HasAttribute("textBox1", typeof(ABCAttribute));
    
    public static bool HasAttribute(this object item, string memberName, Type attribute)
    {
        MemberInfo[] members = item.GetType().GetMember(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if(members.Length > 0)
        {
            object[] attribs = members[0].GetCustomAttributes(attribute);
            if(attribs.length > 0)
            {
                return true;
            }
        }
        return false;
    }
