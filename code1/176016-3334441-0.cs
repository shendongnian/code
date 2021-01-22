    class Foo
    {
        public Foo()
        {
            _bars = new ObservableCollection<Bar>();
            Bars = new CollectionViewSource { Source = _bars }.View;
        }
        private ObservableCollection<Bar> _bars;
        public ICollectionView Bars { get; private set; }
        public void Filter(string quxName)
        {
            Bars.Filter = o => ((Bar)o).Quxes.Any(q => q.Name == quxName);
            foreach (Bar bar in Bars)
            {
                bar.Filter(quxName);
            }
        }
    }   
    class Bar
    {
        private ObservableCollection<Qux> _quxes;
        public ICollectionView Quxes { get; private set; }
        public void Filter(string quxName)
        {
            Quexs.Filter = o => ((Qux)o).Name == quxName;
        }
    }
    class Qux
    {
        public string Name { get; set; }
    }
