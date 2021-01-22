    public class GeneralIndexer<R,P>
        {
            // Delegates
            public delegate R gen_get(P parm);
            public delegate void gen_set(P parm, R value);
            public delegate P[] key_get();
    
            // Events
            public event gen_get GetEvent;
            public event gen_set SetEvent;
            public event key_get KeyRequest;
    
            public R this[P parm]
            {
                get { return GetEvent.Invoke(parm); }
                set { SetEvent.Invoke(parm, value); }
            }
    
            public P[] Keys
            {
                get
                {
                    return KeyRequest.Invoke();
                }
            }
    
        }
