    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    
    public sealed class LineReader : IEnumerable<string>
    {
        readonly Func<TextReader> dataSource;
    
        public LineReader(string filename)
            : this(() => File.OpenText(filename))
        {
        }
    
        public LineReader(Func<TextReader> dataSource)
        {
            this.dataSource = dataSource;
        }
    
        public IEnumerator<string> GetEnumerator()
        {
            using (TextReader reader = dataSource())
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
