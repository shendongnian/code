    class NotificationDictionary
    {
        private Dictionary<string, INotificationKey> m_dic =
            new Dictionary<string, INotificationKey>();
        public void Add(INotificationKey obj)
        {
            m_dic.Add(obj.Key, obj);
        }
        public void Remove(string key)
        {
            m_dic.Remove(key);
        }
        public INotificationKey this[string key]
        {
            get { return m_dic[key]; }
        }
    }
