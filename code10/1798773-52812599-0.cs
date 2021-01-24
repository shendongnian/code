    class VmWord
    {
        public int Id { get; set; }
        // every VmWord has zero or more Localizations (one-to-many)
        public virtual ICollection<VmWordLocalization> VmWordLocalizations { get; set; }
        ... // other properties
    }
    class VmWordLocalization
    {
        public int Id { get; set; }
        // every VmWordLocalization belongs to exactly one VmWord using foreign key
        public int VmWordId {get; set;}
        public virtual VmWord VmWord {get; set;}
        // every VmWordLocalization has a property Key, which is unique in combination
        // with VmWordId
        public string Key {get; set;}
    }
