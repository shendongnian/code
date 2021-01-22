    interface IHasGuidId {
        Guid GuidId { get; }
    }
    class NewClass : IHasGuidId {
        public Guid GuidId { get; private set; }
        // etc.
    }
    class AdapterClass : IHasGuidId {
        private LegacyClass legacy;
        public Guid GuidId {
            get {
                // obtain and return legacy._guidId;
            }
        }
        // constructor eating instance of LegacyClass etc.
    }
