    public class Source
    {
        Source()
        {
            m_collection = new ObservableCollection<int>();
            m_collectionReadOnly = new ReadOnlyObservableCollection<int>(m_collection);
        }
     
        public ReadOnlyObservableCollection<int> Items
        {
            get { return m_collectionReadOnly; }
        }
     
        readonly ObservableCollection<int> m_collection;
        readonly ReadOnlyObservableCollection<int> m_collectionReadOnly;
    }
