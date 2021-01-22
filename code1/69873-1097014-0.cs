    interface IInfoProvider {
        String Info { get; }
    }
    
    class User : IInfoProvider {
        …
        public override String Info { get { return "Human"; } }
    }
    
    class ListBoxView {
        …
        public override string ToString()
        {
            IInfoProvider infovalue = m_value as IInfoProvider;
            if (infovalue != null)
                return infovalue.Info;
            else
                return "Not defined: " + m_value.GetType().ToString();
        }
    }
