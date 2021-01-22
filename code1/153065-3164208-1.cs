    public abstract class BaseConfigurationElementCollection<TConfigurationElementType> : ConfigurationElementCollection, IList<TConfigurationElementType> where TConfigurationElementType : ConfigurationElement, IConfigurationElementCollectionElement, new()
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TConfigurationElementType();
        }
 
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TConfigurationElementType)element).ElementKey;
        }
 
        public IEnumerator<TConfigurationElement> GetEnumerator()
        {
            foreach (TConfigurationElement type in this)
            {
                yield return type;
            }
        }
 
        public void Add(TConfigurationElementType configurationElement)
        {
            BaseAdd(configurationElement, true);
        }
 
        public void Clear()
        {
            BaseClear();
        }
 
        public bool Contains(TConfigurationElementType configurationElement)
        {
            return !(IndexOf(configurationElement) < 0);
        }
 
        public void CopyTo(TConfigurationElementType[] array, int arrayIndex)
        {
            base.CopyTo(array, arrayIndex);
        }
 
        public bool Remove(TConfigurationElementType configurationElement)
        {
            BaseRemove(GetElementKey(configurationElement));
 
            return true;
        }
 
        bool ICollection<TConfigurationElementType>.IsReadOnly
        {
            get { return IsReadOnly(); }
        }
 
        public int IndexOf(TConfigurationElementType configurationElement)
        {
            return BaseIndexOf(configurationElement);
        }
 
        public void Insert(int index, TConfigurationElementType configurationElement)
        {
            BaseAdd(index, configurationElement);
        }
 
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
 
        public TConfigurationElementType this[int index]
        {
            get
            {
                return (TConfigurationElementType)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
    }
