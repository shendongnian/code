    public class MyNoCookiesInTheJarDynamicObject : DynamicObject
    {
        Dictionary<string, object> properties = new Dictionary<string, object>();
 
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (properties.ContainsKey(binder.Name))
            {
                result = properties[binder.Name];
                return true;
            }
            else
            {
                result = "I'm sorry, there are no cookies in this jar!"; //<-- THIS IS OUR 
                CUSTOM "NO COOKIES IN THE JAR" RESPONSE FROM OUR DYNAMIC TYPE WHEN AN UNKNOWN FIELD IS ACCESSED
                return false;
            }
        }
 
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            properties[binder.Name] = value;
            return true;
        }
 
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            dynamic method = properties[binder.Name];
            result = method(args[0].ToString(), args[1].ToString());
            return true;
        }
    }
