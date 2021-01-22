    public class Allocation<TActivity> 
        where TActivity : AllocatableActivity<TActivity>
    {
        public AllocatableResource Resource { get; private set; }
        public TActivity Activity { get; private set; }
        public TimeQuantity Period { get; private set; }
        public Allocation(AllocatableResource resource, TActivity activity, DateTime eventDate, TimeQuantity timeSpent)
        {
            Check.RequireNotNull<IResource>(resource);
            Resource = resource;
            Check.RequireNotNull<Activities.Activity>(activity);
            Activity = activity;
            Check.Require(timeSpent.Amount >= 0, Msgs.Allocation_NegativeTimeSpent);
            TimeSpentPeriod = _toTimeSpentPeriod(eventDate, timeSpent);
        }
    }
    public class AllocatableActivity<TActivity>
    {
        public string Description { get; protected set; }
        public string BusinessId { get; protected set; }
        protected readonly IDictionary<DateTime, Allocation<TActivity>> _allocations;
        public virtual void ClockIn(DateTime eventDate, AllocatableResource resource, TimeQuantity timeSpent)
        {
            var entry = new Allocation<TActivity>(resource, this, eventDate, timeSpent);
            if (_allocations.ContainsKey(eventDate))
            {
                Check.Require(_allocations[eventDate].Resource.Equals(resource),
                          "This method requires that the same resource is the resource in this allocation.");
                _allocations[eventDate] = entry;
            }
            else _allocations.Add(eventDate, entry);
        }
    }
