    public class Customer : IChangeTrackable
    {
        public DirtyState Status
        {
            get; set;
        }
    
        [ChangeTrackingProperty]
        public string Name
        { get; set; }
    }
