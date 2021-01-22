    public static class LineProcessorLinq
    {
        public static LineProcessor Load(this string fileName)
        {
            return new LineProcessor(fileName);
        }
    
        public static void Write(this IEnumerable<string> lines, string header, string footer, string fileName)
        {
            using (var fs = File.AppendText(fileName))
                lines.Write(header, footer, fs);
        }
    
        public static void Write(this IEnumerable<string> lines, string header, string footer, StreamWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
    
            if (!string.IsNullOrEmpty(header))
                writer.Write(header);
    
            foreach (var line in lines)
                writer.Write(line);
    
            if (!string.IsNullOrEmpty(footer))
                writer.Write(footer);
        }
    }
    public class LineProcessor : Component, IEnumerable<string>
    {
        private StreamReader _reader = null;
    
        public LineProcessor(string fileName) : this(File.OpenText(fileName)) { }
    
        public LineProcessor(StreamReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");
            _reader = reader;
        }
    
        protected override void Dispose(bool disposing)
        {
            if (disposing && _reader != null)
                _reader.Close();
        }
    
        #region IEnumerable<string> Members
    
        public IEnumerator<string> GetEnumerator()
        {
            var currentPos = _reader.BaseStream.Position;
            while (!_reader.EndOfStream)
                yield return _reader.ReadLine();
            if (_reader.BaseStream.CanSeek)
                _reader.BaseStream.Seek(currentPos, SeekOrigin.Begin);
        }
    
        #endregion
    
        #region IEnumerable Members
    
        IEnumerator IEnumerable.GetEnumerator() { throw new NotImplementedException(); }
    
        #endregion
    }
