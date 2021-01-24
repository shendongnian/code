    class LegacyClass
    {
        [Obsolete("Use NewMember instead")]
        public string ExistingMember { get; set; } // should actually be immutable
        public string NewMember { get { ... } }
    }
