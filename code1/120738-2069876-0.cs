        public class IndexReader: INotifyPropertyChanged
        {
            public IEnumerable<string> IndexFiles 
                { get { ... } set { ... raise notify } }
            
            public void ReadIndexImagesFromFolder(string folder)
            {
    ...
            }
        }
