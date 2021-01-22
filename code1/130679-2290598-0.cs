    class MergeFile : IEnumerator<string>
    {
        private readonly StreamReader _reader;
        public MergeFile(string file)
        {
            _reader = File.OpenText(file);
            Current = _reader.ReadLine();
        }
        public string Current { get; set; }
        public void Dispose()
        {
            _reader.Close();
        }
        public bool MoveNext()
        {
            Current = _reader.ReadLine();
            return Current != null;
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
