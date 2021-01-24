    public abstract class UnclaimedProperty<T> where T : UnclaimedProperty<T> {
        public abstract string Key { get; }
        public virtual void Process() { }
        public virtual void Process(string FileName) { }
        abstract public void WriteReport(List<T> PropertyRecords, string FileName);
    }
     
