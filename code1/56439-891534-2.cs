	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Runtime.InteropServices;
	namespace PersonalUse.IO {
		public sealed class RecordReader<T> : IDisposable, IEnumerable<T> where T : new() {
			const int DEFAULT_STREAM_BUFFER_SIZE = 2 << 16; // default stream buffer (64k)
			const int DEFAULT_RECORD_BUFFER_SIZE = 100; // default record buffer (100 records)
			readonly long _fileSize; // size of the underlying file
			readonly int _recordSize; // size of the record structure
			byte[] _buffer; // the buffer itself, [record buffer size] * _recordSize
			FileStream _fs;
			T[] _structBuffer;
			GCHandle _h; // handle/pinned pointer to _structBuffer 
			int _recordsInBuffer; // how many records are in the buffer
			int _bufferIndex; // the index of the current record in the buffer
			long _recordPosition; // position of the record in the file
			/// <overloads>Initializes a new instance of the <see cref="RecordReader{T}"/> class.</overloads>
			/// <summary>
			/// Initializes a new instance of the <see cref="RecordReader{T}"/> class.
			/// </summary>
			/// <param name="filename">filename to be read</param>
			public RecordReader(string filename) : this(filename, DEFAULT_STREAM_BUFFER_SIZE, DEFAULT_RECORD_BUFFER_SIZE) { }
			/// <summary>
			/// Initializes a new instance of the <see cref="RecordReader{T}"/> class.
			/// </summary>
			/// <param name="filename">filename to be read</param>
			/// <param name="streamBufferSize">buffer size for the underlying <see cref="FileStream"/>, in bytes.</param>
			public RecordReader(string filename, int streamBufferSize) : this(filename, streamBufferSize, DEFAULT_RECORD_BUFFER_SIZE) { }
			/// <summary>
			/// Initializes a new instance of the <see cref="RecordReader{T}"/> class.
			/// </summary>
			/// <param name="filename">filename to be read</param>
			/// <param name="streamBufferSize">buffer size for the underlying <see cref="FileStream"/>, in bytes.</param>
			/// <param name="recordBufferSize">size of record buffer, in records.</param>
			public RecordReader(string filename, int streamBufferSize, int recordBufferSize) {
				_fileSize = new FileInfo(filename).Length;
				_recordSize = Marshal.SizeOf(typeof(T));
				_buffer = new byte[recordBufferSize * _recordSize];
				_fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None, streamBufferSize, FileOptions.SequentialScan);
				_structBuffer = new T[recordBufferSize];
				_h = GCHandle.Alloc(_structBuffer, GCHandleType.Pinned);
				FillBuffer();
			}
			// fill the buffer, reset position
			void FillBuffer() {
				int bytes = _fs.Read(_buffer, 0, _buffer.Length);
				Marshal.Copy(_buffer, 0, _h.AddrOfPinnedObject(), _buffer.Length);
				_recordsInBuffer = bytes / _recordSize;
				_bufferIndex = 0;
			}
			/// <summary>
			/// Read a record
			/// </summary>
			/// <returns>a record of type T</returns>
			public T Read() {
				if(_recordsInBuffer == 0)
					return new T(); //EOF
				if(_bufferIndex < _recordsInBuffer) {
					// update positional info
					_recordPosition++;
					return _structBuffer[_bufferIndex++];
				} else {
					// refill the buffer
					FillBuffer();
					return Read();
				}
			}
			/// <summary>
			/// Advances the record position without reading.
			/// </summary>
			public void Next() {
				if(_recordsInBuffer == 0)
					return; // EOF
				else if(_bufferIndex < _recordsInBuffer) {
					_bufferIndex++;
					_recordPosition++;
				} else {
					FillBuffer();
					Next();
				}
			}
			public long FileSize {
				get { return _fileSize; }
			}
			public long FilePosition {
				get { return _recordSize * _recordPosition; }
			}
			public long RecordSize {
				get { return _recordSize; }
			}
			public long RecordPosition {
				get { return _recordPosition; }
			}
			public bool EOF {
				get { return _recordsInBuffer == 0; }
			}
			public void Close() {
				Dispose(true);
			}
			void Dispose(bool disposing) {
				try {
					if(disposing && _fs != null) {
						_fs.Close();
					}
				} finally {
					if(_fs != null) {
						_fs = null;
						_buffer = null;
						_recordPosition = 0;
						_bufferIndex = 0;
						_recordsInBuffer = 0;
					}
					if(_h.IsAllocated) {
						_h.Free();
						_structBuffer = null;
					}
				}
			}
			#region IDisposable Members
			public void Dispose() {
				Dispose(true);
			}
			#endregion
			#region IEnumerable<T> Members
			public IEnumerator<T> GetEnumerator() {
				while(_recordsInBuffer != 0) {
					yield return Read();
				}
			}
			#endregion
			#region IEnumerable Members
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
				return GetEnumerator();
			}
			#endregion
		} // end class
	} // end namespace
