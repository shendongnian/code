    public class SomeContext
    {
        public SomeContext(object stateData1, object stateData2)
        {
            StateData1 = stateData1;
            StateData2 = stateData2;
        }
    
        public virtual object StateData1 { get; private set; }
        public virtual object StateData2 { get; private set; }
        [ThreadStatic]
        private static SomeContext m_threadInstance;    
        public static SomeContext Current
        {
            get
            {
                return m_threadInstance;
            }
            set
            {
                if (value != null && m_threadInstance != null) 
                    throw new InvalidOperationException("This context has already been initialized for the current thread.");
                m_threadInstance = value;
            }
        }
    }
    public class SomeContextScope: IDisposable
    {
        public SomeContextScope(object stateData1, object stateData2)
        {
            if (SomeContext.Current == null)
            {
                SomeContext context = new SomeContext(stateData1, stateData2);
                SomeContext.Current = context;
                m_contextCreated = true;
            }
        }
        private bool m_contextCreated;
        public void Dispose()
        {
            if (m_contextCreated)
            {
                SomeContext.Current = null;
            }
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
        using (SomeContextScope scope = new SomeContextScope(stateData1, stateData2))
        {    
            // ... do some work
    
            var processor = complexProcessorFactory.CreateInstance();
            processor.DoProcesing(data);
    
            // ... do more work
        }
    }
