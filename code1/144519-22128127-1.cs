        public class OffsetStreamReader
        {
            private const int InitialBufferSize = 4096;    
            private readonly char _bom;
            private readonly byte _end;
            private readonly Encoding _encoding;
            private readonly Stream _stream;
            private readonly bool _tail;
            private byte[] _buffer;
            private int _processedInBuffer;
            private int _informationInBuffer;
            
            public OffsetStreamReader(Stream stream, bool tail)
            {
                _buffer = new byte[InitialBufferSize];
                _processedInBuffer = InitialBufferSize;
                if (stream == null || !stream.CanRead)
                    throw new ArgumentException("stream");
                _stream = stream;
                _tail = tail;
                _encoding = Encoding.UTF8;
                _bom = '\uFEFF';
                _end = _encoding.GetBytes(new [] {'\n'})[0];
            }
            public long Offset { get; private set; }
            public string ReadLine()
            {
                // Underlying stream closed
                if (!_stream.CanRead)
                    return null;
                // EOF
                if (_processedInBuffer == _informationInBuffer)
                {
                    if (_tail)
                    {
                        _processedInBuffer = _buffer.Length;
                        _informationInBuffer = 0;
                        ReadBuffer();
                    }
                    return null;
                }
                var lineEnd = Search(_buffer, _end, _processedInBuffer);
                // No end in current buffer
                if (!lineEnd.HasValue)
                {
                    ReadBuffer();
                    if (_informationInBuffer != 0)
                        return ReadLine();
                    return null;
                }
                var arr = new byte[lineEnd.Value - _processedInBuffer];
                Array.Copy(_buffer, _processedInBuffer, arr, 0, arr.Length);
                Offset = Offset + lineEnd.Value - _processedInBuffer + 1;
                _processedInBuffer = lineEnd.Value + 1;
                return _encoding.GetString(arr).TrimStart(_bom).TrimEnd('\r', '\n');
            }
            
            private void ReadBuffer()
            {
                var notProcessedPartLength = _buffer.Length - _processedInBuffer;
                // Extend buffer to be able to fit whole line to the buffer
                // Was     [NOT_PROCESSED]
                // Become  [NOT_PROCESSED        ]
                if (notProcessedPartLength == _buffer.Length)
                {
                    var extendedBuffer = new byte[_buffer.Length + _buffer.Length/2];
                    Array.Copy(_buffer, extendedBuffer, _buffer.Length);
                    _buffer = extendedBuffer;
                }
                // Copy not processed information to the begining
                // Was    [PROCESSED NOT_PROCESSED]
                // Become [NOT_PROCESSED          ]
                Array.Copy(_buffer, (long) _processedInBuffer, _buffer, 0, notProcessedPartLength);
                // Read more information to the empty part of buffer
                // Was    [ NOT_PROCESSED                   ]
                // Become [ NOT_PROCESSED NEW_NOT_PROCESSED ]
                _informationInBuffer = notProcessedPartLength + _stream.Read(_buffer, notProcessedPartLength, _buffer.Length - notProcessedPartLength);
                _processedInBuffer = 0;
            }
            
            private int? Search(byte[] buffer, byte byteToSearch, int bufferOffset)
            {
                for (int i = bufferOffset; i < buffer.Length - 1; i++)
                {
                    if (buffer[i] == byteToSearch)
                        return i;
                }
                return null;
            }
        }
