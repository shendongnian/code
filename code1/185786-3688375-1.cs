    public class DefaultMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Member member)
        {
            if (member.IsProperty && !member.CanWrite)
            {
                return false;
            }
            return base.ShouldMap(member);
        }
    }
