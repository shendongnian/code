    class Program
    {
        [ImportMany("AddinContractName", typeof(IRunMe))]
        public IEnumerable<IRunMe> ThingsToRun { get; set; }
        
        void SomeFunc()
        {
            foreach(IRunMe thing in ThingsToRun)
            {
                thing.Run();
            }
            /* do whatever else ... */
        }
    }
