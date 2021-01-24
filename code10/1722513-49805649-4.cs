    internal class ReachIn : DynamicObject
    {
        private readonly Type type;
        private readonly string @namespace;
        public ReachIn(Type type = null, string @namespace = null)
        {
            this.type = type;
            this.@namespace = @namespace;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (type == null)
            {
                result = new ReachIn(Type.GetType($"{@namespace}.{binder.Name}".Trim('.')));
                return true;
            }
            var member = type.GetMember(binder.Name).Single(); 
            if (member.MemberType == MemberTypes.NestedType)
            {
                result = new ReachIn((Type)member);
            }
            else if (member.MemberType == MemberTypes.Property)
            {
                result = ((PropertyInfo)member).GetValue(null);
            }
            else
            {
                result = null;
                return false;
            }
            return true;
        }
 
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var member = type.GetMember(binder.Name).Single();
            if (member.MemberType == MemberTypes.Property)
            {
                ((PropertyInfo)member).SetValue(null, value);
                return true;
            }
            return false;
        }
    }
