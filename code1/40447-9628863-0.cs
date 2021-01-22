    //Don't Serialize Time Span object.
            [XmlIgnore]
            public TimeSpan m_timeSpan;
    //Instead serialize (long)Ticks and instantiate Timespan at time of deserialization.
            public long m_TimeSpanTicks
            {
                get { return m_timeSpan.Ticks; }
                set { m_timeSpan = new TimeSpan(value); }
            }
