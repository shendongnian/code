    public class Role
    {
        public string lala { get; set; }
        public string abab { get; set; }
        public string cxcx { get; set; }
    }
    // Very likely this could just be an interface. There's not much use for
    // an abstract class that doesn't implement anything. It effectively *is* 
    // an interface.
    public abstract class RoleMembersProvider<TRole> where TRole : Role
    {
        public abstract List<TRole> GetMembers();
    }
    public class Role1MemberProvider : RoleMemberProvider<Role1>
    {
        public override List<Role1> GetMembers()
        {
            return dataaccesslayer.GetRole1Members();
        }
    }
