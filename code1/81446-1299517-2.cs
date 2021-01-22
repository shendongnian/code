    public class Bar
    {
        public readonly TriggerField<string> Flibble;
        private int versionCount = 0;
    	
        public Bar()
        {
            Flibble = new TriggerField<string>((old,current) => this.versionCount++);
        }
    }
