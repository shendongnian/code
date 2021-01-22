    class Cats
    {
        private Dictionary<string, INotifyPropertyChanged> m_dic =
            new Dictionary<string, INotifyPropertyChanged>();
        public void Add(INotifyPropertyChanged obj)
        {
            m_dic.Add(obj.Name, obj);
        }
        public void Remove(string name)
        {
            m_dic.Remove(name);
        }
        public INotifyPropertyChanged this[string name]
        {
            get { return m_dic[name]; }
        }
    }
