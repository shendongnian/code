    public class AllocatableActivity<TActivity>
    {
        protected readonly IDictionary<DateTime, Allocation<TActivity>> _allocations;
        public virtual void ClockIn<TResource>(
            DateTime eventDate, TResource resource, TimeQuantity timeSpent) 
            where TResource : Resource
        {
            var entry = new Allocation<TActivity, TResource>(
                resource, this, eventDate, timeSpent);
            if (_allocations.ContainsKey(eventDate))
            {
                Check.Require(_allocations[eventDate].Resource.Equals(resource),
                              "This method requires that the same resource is the resource in this allocation.");
                _allocations[eventDate] = entry;
            }
            else _allocations.Add(eventDate, entry);
        }
    }
    
