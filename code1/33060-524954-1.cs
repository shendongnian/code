    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    public class AsyncStreamProcessor : IDisposable
    {
        protected StringBuilder _buffer;  // Buffer for unprocessed data.
    
        private bool _isDisposed = false; // True if object has been disposed
    
        public AsyncStreamProcessor()
        {
            _buffer = null;
        }
    
        public IEnumerable<string> Process(byte[] newData)
        {
            // Note: replace the following encoding method with whatever you are reading.
            // The trick here is to add an extra line break to the new data so that the algorithm recognises
            // a single line break at the end of the new data.
            using(var newDataReader = new StringReader(Encoding.ASCII.GetString(newData) + Environment.NewLine))
            {
                // Read all lines from new data, returning all but the last.
                // The last line is guaranteed to be incomplete (or possibly complete except for the line break,
                // which will be processed with the next packet of data).
                string line, prevLine = null;
                while ((line = newDataReader.ReadLine()) != null)
                {
                    if (prevLine != null)
                    {
                        yield return (_buffer == null ? string.Empty : _buffer.ToString()) + prevLine;
                        _buffer = null;
                    }
                    prevLine = line;
                }
    
                // Store last incomplete line in buffer.
                if (_buffer == null)
                    // Note: the (* 2) gives you the prediction of the length of the incomplete line, 
                    // so that the buffer does not have to be expanded in most/all situations. 
                    // Change it to whatever seems appropiate.
                    _buffer = new StringBuilder(prevLine, prevLine.Length * 2);
                else
                    _buffer.Append(prevLine);
            }
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    _buffer = null;
                    GC.Collect();
                }
    
                // Dispose native resources.
                
                // Remember that object has been disposed.
                _isDisposed = true;
            }
        }
    }
