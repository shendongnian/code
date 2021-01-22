    public class MyEntity
    {
        [NotMapped]
        public bool A => true;
    }
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Member member)
        {
            if (member.MemberInfo.GetCustomAttributes(typeof(NotMappedAttribute), true).Length > 0)
            {
                return false;
            }
            return base.ShouldMap(member);
        }
    }
