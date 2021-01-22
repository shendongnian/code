    public abstract class Resource
    {
        public string Description { get; }
    }
    public class AllocatableResource<TResource> where TResource : Resource
    {
        ...
    }
    public abstract class Allocation<TActivity>
    {
        protected Allocation(
            Resource resource, TActivity activity, TimeQuantity period)
        {
            this.Resource = resource;
            this.Activity = activity;
            this.Period = period;
        }
        public virtual Resource Resource { get; protected set; }
        public TActivity Activity { get; protected set; }
        public TimeQuantity Period { get; protected set; }
    }
    public class Allocation<TActivity, TResource> : Allocation<TActivity>
        where TActivity : AllocatableActivity<TActivity>
        where TResource : AllocatableResource<TResource>
    {
        public new TResource Resource { get; private set; }
        public Allocation(
            TResource resource, TActivity activity, DateTime eventDate,
            TimeQuantity timeSpent)
            : base(resource, activity, timeSpent)
        {
            ...
        }
    }
