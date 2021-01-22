    public partial class Group
    {
        public ObjectQuery<Member> Members
        {
            get
            {
                return (from j in DataModel.MemberGroup
                        where j.Group.ID == this.ID
                        select j.Member) as ObjectQuery<Member>;
            }
        }
    }
