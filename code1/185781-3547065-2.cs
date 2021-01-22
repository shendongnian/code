    public class DefaultMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Member member)
        {
            return member.CanWrite;
        }
    }
