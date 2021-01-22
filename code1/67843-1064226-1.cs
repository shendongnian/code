    public static TThis Singleton
    {
        get
        {
            lock (m_lock)
            {
                if (m_factory == null)
                {
					var attr = Attribute.GetCustomAttribute( 
					               typeof( TThis ), 
					               typeof( SingletonFactoryAttribute ) ) 
					               as SingletonFactoryAttribute;
                    
                    if (attr == null)
                        throw new InvalidOperationException(string.Format(
                            CultureInfo.InvariantCulture,
                            "{0} does not have a SingletonFactoryAttribute.",
                            typeof(TThis).ToString()));
                            
                    m_factory = Activator.CreateInstance( attr.FactoryType );
                }
                if (m_singleton == null || m_singleton.IsDisposed)
                {
                    m_singleton = m_factory.GetNew();
                }
                return m_singleton;
            }
        }
    } 
