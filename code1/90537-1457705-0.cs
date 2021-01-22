    public class AhpUserFilter : FilterBindingListAdapter<AhpUser>
    {
        public AhpUserFilter(AhpUserCollection users)
            : base(users.GetList() as IBindingList)
        {
        }
        protected override bool ISVisible(AhpUser user)
        {
            return user.CanEdit;
        }
    }
