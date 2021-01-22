    public class StaticLocalVariable<T>
    {
        private static Dictionary<int, T> s_GlobalStates = new Dictionary<int, T>();
        
        private int m_StateKey;
        public StaticLocalVariable()
        {
            Initialize(default(T));
        }
        public StaticLocalVariable( T value )
        {
            Initialize(value);
        }        
        private void Initialize( T value )
        {
            m_StateKey = new StackTrace(false).GetFrame(2).GetNativeOffset();
            
            if (!s_GlobalStates.ContainsKey(m_StateKey))
            {                
                s_GlobalStates.Add(m_StateKey, value);
            }
        }
        public T Value
        {
            set { s_GlobalStates[m_StateKey] = value; }
            get { return s_GlobalStates[m_StateKey]; }
        }
    }
