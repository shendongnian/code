    public class XmlTimeSpan
    {
        private const long TICKS_PER_MS = TimeSpan.TicksPerMillisecond;
    
        private TimeSpan m_value = TimeSpan.Zero;
    
        public XmlTimeSpan() { }
        public XmlTimeSpan(TimeSpan source) { m_value = source; }
    
        public static implicit operator TimeSpan?(XmlTimeSpan o)
        {
            return o == null ? default(TimeSpan?) : o.m_value;
        }
    
        public static implicit operator XmlTimeSpan(TimeSpan? o)
        {
            return o == null ? null : new XmlTimeSpan(o.Value);
        }
    
        public static implicit operator TimeSpan(XmlTimeSpan o)
        {
            return o == null ? default(TimeSpan) : o.m_value;
        }
    
        public static implicit operator XmlTimeSpan(TimeSpan o)
        {
            return o == default(TimeSpan) ? null : new XmlTimeSpan(o);
        }
    
        [XmlText]
        public long Default
        {
            get { return m_value.Ticks / TICKS_PER_MS; }
            set { m_value = new TimeSpan(value * TICKS_PER_MS); }
        }
    }
