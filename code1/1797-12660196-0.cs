    class YourClass
    {
        private IEnumerator<Image> enumerator;
        
        YourClass(IEnumerable<Image> images)
        {
            enumerator = (from i in Enumerable.Range(0, int.Max)
                          from image in images
                          select image).GetEnumerator();
            enumerator.MoveNext();
        }
        
        public Image CurrentImage { get { return enumerator.Current; } }
        
        public void OnButtonClick() { enumerator.MoveNext(); }
    }
