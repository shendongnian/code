    public class SomeContext
    {
        public SomeContext(object stateData1, object stateData2)
        {
            StateData1 = stateData1;
            StateData2 = stateData2;
        }
    
        public virtual object StateData1 { get; private set; }
        public virtual object StateData2 { get; private set; }
    
        public static SomeContext Current
        {
            get; set;
        }
    }
    
    public class ComplexProcessor
    {
        public ComplexProcessor(...) // Lots of dependencies injected
    
        public void DoProcessing(BaseClass instance)
        {
            // do some work with instance
    
            if (SomeContext.Current != null)
            {
                // do contextually sensitive stuff for SomeContext with instance
                // call a dependency that does contextually sensitive stuff
            }
            // do some more work with instance
            // call a dependency that does contextually sensitive stuff
    
            if (SomeOtherContext.Current != null)
            {
                // do contextually sensitive stuff for SomeOtherContext with instance
                // call a dependency that does contextually sensitive stuff
            }
            // call a dependency that does contextually sensitive stuff
        }
    }
    
    // The original setup of the context and initiation of processing
    
    public void SomeOperation(...)
    {
        SomeContext.Current = new SomeContext(stateData1, stateData2);
    
        // ... do some work
    
        var processor = complexProcessorFactory.CreateInstance();
        processor.DoProcesing(data);
    
        // ... do more work
        SomeContext.Current = null;
    }
