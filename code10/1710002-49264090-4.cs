    //
    //   Copyright (c) Microsoft Corporation.  All rights reserved.
    //
    // ==--== 
    /*============================================================
    ** 
    ** Class:  AsyncStreamReader 
    **
    ** Purpose: For reading text from streams using a particular 
    ** encoding in an asychronous manner used by the process class
    **
    **
    ===========================================================*/
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Threading;
    
    namespace System.Diagnostics
    {
    	/// <summary>
    	/// http://www.dotnetframework.org/default.aspx/DotNET/DotNET/8@0/untmp/whidbey/REDBITS/ndp/fx/src/Services/Monitoring/system/Diagnosticts/AsyncStreamReader@cs/1/AsyncStreamReader@cs
    	/// </summary>
    	public sealed class AsyncStreamReader : DisposableBase, IDisposable
    	{
    		internal const int DEFAULT_BUFFER_SIZE = 4096;  // Byte buffer size
    		private const int MIN_BUFFER_SIZE = 128;
    
    		private Decoder _decoder;
    		private byte[] _byteBuffer;
    		private char[] _charBuffer;
    		// Record the number of valid bytes in the byteBuffer, for a few checks. 
    
    		// This is the maximum number of chars we can get from one call to
    		// ReadBuffer.  Used so ReadBuffer can tell when to copy data into
    		// a user's char[] directly, instead of our internal char[]. 
    		private int _maxCharsPerBuffer;
    
    		// Store a backpointer to the process class, to check for user callbacks 
    		private Process _process;
    		private StringBuilder _sb;
    
    		// Delegate to call user function.
    		private Action<string> _userCallBack;
    
    		// Internal Cancel operation 
    		private bool _cancelOperation;
    		private ManualResetEvent _eofEvent;
    
    		public AsyncStreamReader(Process process, Stream stream, Action<string> callback, Encoding encoding)
    			: this(process, stream, callback, encoding, DEFAULT_BUFFER_SIZE)
    		{
    		}
    
    
    		// Creates a new AsyncStreamReader for the given stream.  The 
    		// character encoding is set by encoding and the buffer size,
    		// in number of 16-bit characters, is set by bufferSize. 
    		public AsyncStreamReader(Process process, Stream stream, Action<string> callback, Encoding encoding, int bufferSize)
    		{
    			Debug.Assert(process != null && stream != null && encoding != null && callback != null, "Invalid arguments!");
    			Debug.Assert(stream.CanRead, "Stream must be readable!");
    			Debug.Assert(bufferSize > 0, "Invalid buffer size!");
    			Init(process, stream, callback, encoding, bufferSize);
    		}
    
    		private void Init(Process process, Stream stream, Action<string> callback, Encoding encoding, int bufferSize)
    		{
    			_process = process;
    			BaseStream = stream;
    			CurrentEncoding = encoding;
    			_userCallBack = callback;
    			_decoder = encoding.GetDecoder();
    			if (bufferSize < MIN_BUFFER_SIZE) bufferSize = MIN_BUFFER_SIZE;
    			_byteBuffer = new byte[bufferSize];
    			_maxCharsPerBuffer = encoding.GetMaxCharCount(bufferSize);
    			_charBuffer = new char[_maxCharsPerBuffer];
    			_sb = new StringBuilder(_charBuffer.Length);
    			_cancelOperation = false;
    			_eofEvent = new ManualResetEvent(false);
    		}
    
    		public void Close()
    		{
    			Dispose(true);
    		}
    
    		void IDisposable.Dispose()
    		{
    			Dispose(true);
    		}
    
    		protected override void Dispose(bool disposing)
    		{
    			if (disposing)
    			{
    				if (BaseStream != null)
    				{
    					BaseStream.Close();
    					BaseStream = null;
    				}
    			}
    
    			if (BaseStream != null)
    			{
    				BaseStream = null;
    				CurrentEncoding = null;
    				_decoder = null;
    				_byteBuffer = null;
    				_charBuffer = null;
    			}
    
    			if (_eofEvent != null)
    			{
    				_eofEvent.Close();
    				_eofEvent = null;
    			}
    		}
    
    		public Encoding CurrentEncoding { get; private set; }
    
    		public Stream BaseStream { get; private set; }
    
    		// User calls BeginRead to start the asynchronous read
    		public void BeginRead()
    		{
    			_cancelOperation = false;
    			BaseStream.BeginRead(_byteBuffer, 0, _byteBuffer.Length, ReadBuffer, null);
    		}
    
    		public void CancelOperation()
    		{
    			_cancelOperation = true;
    		}
    
    		// This is the async callback function. Only one thread could/should call this.
    		private void ReadBuffer(IAsyncResult ar)
    		{
    			if (_cancelOperation) return;
    
    			int byteLen;
    
    			try
    			{
    				byteLen = BaseStream.EndRead(ar);
    			}
    			catch (IOException)
    			{
    				// We should ideally consume errors from operations getting cancelled
    				// so that we don't crash the unsuspecting parent with an unhandled exc. 
    				// This seems to come in 2 forms of exceptions (depending on platform and scenario),
    				// namely OperationCanceledException and IOException (for errorcode that we don't 
    				// map explicitly). 
    				byteLen = 0; // Treat this as EOF
    			}
    			catch (OperationCanceledException)
    			{
    				// We should consume any OperationCanceledException from child read here
    				// so that we don't crash the parent with an unhandled exc
    				byteLen = 0; // Treat this as EOF 
    			}
    
    			if (byteLen == 0)
    			{
    				// We're at EOF, we won't call this function again from here on.
    				_eofEvent.Set();
    			}
    			else
    			{
    				int charLen = _decoder.GetChars(_byteBuffer, 0, byteLen, _charBuffer, 0);
    
    				if (charLen > 0)
    				{
    					_sb.Length = 0;
    					_sb.Append(_charBuffer, 0, charLen);
    					_userCallBack(_sb.ToString());
    				}
    
    				BaseStream.BeginRead(_byteBuffer, 0, _byteBuffer.Length, ReadBuffer, null);
    			}
    		}
    
    		// Wait until we hit EOF. This is called from Process.WaitForExit 
    		// We will lose some information if we don't do this.
    		public void WaitUtilEof()
    		{
    			if (_eofEvent != null)
    			{
    				_eofEvent.WaitOne();
    				_eofEvent.Close();
    				_eofEvent = null;
    			}
    		}
    	}
    }
