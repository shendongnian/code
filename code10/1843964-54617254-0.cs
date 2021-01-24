            public void LoadSubClasses()
        {
            IEnumerable<ParentClass> subClassesIEnumerable = typeof(ParentClass)
                .Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(ParentClass)))
                .Select(t => (ParentClass)Activator.CreateInstance(t));
            foreach (ParentClass _subClass in subClassesIEnumerable)
            {
                _subClassesCollection.Add(_subClass);
            }
        }
        private BindableCollection<ParentClass> _subClassesCollection = new BindableCollection<ParentClass>();
        public BindableCollection<ParentClass> SubClassesCollection
        {
            get { return _subClassesCollection; }
            set { _subClassesCollection = value; NotifyOfPropertyChange(() => SubClassesCollection); }
        }
