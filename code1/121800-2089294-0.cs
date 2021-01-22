    public class MemberProfile : Member
    {
        public MemberProfile(Member member)
        {
            base.field1 = member.field1;
            base.field2 = member.field2;
                .
                .
            base.fieldn = member.fieldn;
        }
    }
