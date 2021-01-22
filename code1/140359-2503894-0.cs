    public class BasePadWI
    {
        protected WorkItem _workItemReference;
        public WorkItem WorkItemReference { get { return _workItemReference; }}
    
    
        public static implicit operator WorkItemReference(BasePadWI item)
        {
           return item._workItemReference;
         }
        .... Other stuff ......
    }
