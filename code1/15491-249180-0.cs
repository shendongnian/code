    class C
    {
        private List<W> _contentsW;
        public List<W> Contents 
        {
            get { return _contentsw; }
        }
      
        public void AddToContents(W content);
        {
            content.Container = this;
            _contentsW.Add(content);
        }
    }
