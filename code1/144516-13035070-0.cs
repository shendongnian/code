	public sealed class TextFileReader : IDisposable
	{
		FileStream _fileStream = null;
		BinaryReader _binReader = null;
		StreamReader _streamReader = null;
		List<string> _lines = null;
		long _length = -1;
		/// <summary>
		/// Initializes a new instance of the <see cref="TextFileReader"/> class with default encoding (UTF8).
		/// </summary>
		/// <param name="filePath">The path to text file.</param>
		public TextFileReader(string filePath) : this(filePath, Encoding.UTF8) { }
		/// <summary>
		/// Initializes a new instance of the <see cref="TextFileReader"/> class.
		/// </summary>
		/// <param name="filePath">The path to text file.</param>
		/// <param name="encoding">The encoding of text file.</param>
		public TextFileReader(string filePath, Encoding encoding)
		{
			if (!File.Exists(filePath))
				throw new FileNotFoundException("File (" + filePath + ") is not found.");
			_fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
			_length = _fileStream.Length;
			_binReader = new BinaryReader(_fileStream, encoding);
		}
		/// <summary>
		/// Reads a line of characters from the current stream at the current position and returns the data as a string.
		/// </summary>
		/// <returns>The next line from the input stream, or null if the end of the input stream is reached</returns>
		public string ReadLine()
		{
			if (_binReader.PeekChar() == -1)
				return null;
			string line = "";
			int nextChar = _binReader.Read();
			while (nextChar != -1)
			{
				char current = (char)nextChar;
				if (current.Equals('\n'))
					break;
				else if (current.Equals('\r'))
				{
					int pickChar = _binReader.PeekChar();
					if (pickChar != -1 && ((char)pickChar).Equals('\n'))
						nextChar = _binReader.Read();
					break;
				}
				else
					line += current;
				nextChar = _binReader.Read();
			}
			return line;
		}
		/// <summary>
		/// Reads some lines of characters from the current stream at the current position and returns the data as a collection of string.
		/// </summary>
		/// <param name="totalLines">The total number of lines to read (set as 0 to read from current position to end of file).</param>
		/// <returns>The next lines from the input stream, or empty collectoin if the end of the input stream is reached</returns>
		public List<string> ReadLines(int totalLines)
		{
			if (totalLines < 1 && this.Position == 0)
				return this.ReadAllLines();
			_lines = new List<string>();
			int counter = 0;
			string line = this.ReadLine();
			while (line != null)
			{
				_lines.Add(line);
				counter++;
				if (totalLines > 0 && counter >= totalLines)
					break;
				line = this.ReadLine();
			}
			return _lines;
		}
		/// <summary>
		/// Reads all lines of characters from the current stream (from the begin to end) and returns the data as a collection of string.
		/// </summary>
		/// <returns>The next lines from the input stream, or empty collectoin if the end of the input stream is reached</returns>
		public List<string> ReadAllLines()
		{
			if (_streamReader == null)
				_streamReader = new StreamReader(_fileStream);
			_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
			_lines = new List<string>();
			string line = _streamReader.ReadLine();
			while (line != null)
			{
				_lines.Add(line);
				line = _streamReader.ReadLine();
			}
			return _lines;
		}
		/// <summary>
		/// Gets the length of text file (in bytes).
		/// </summary>
		public long Length
		{
			get { return _length; }
		}
		/// <summary>
		/// Gets or sets the current reading position.
		/// </summary>
		public long Position
		{
			get
			{
				if (_binReader == null)
					return -1;
				else
					return _binReader.BaseStream.Position;
			}
			set
			{
				if (_binReader == null)
					return;
				else if (value >= this.Length)
					this.SetPosition(this.Length);
				else
					this.SetPosition(value);
			}
		}
		void SetPosition(long position)
		{
			_binReader.BaseStream.Seek(position, SeekOrigin.Begin);
		}
		/// <summary>
		/// Gets the lines after reading.
		/// </summary>
		public List<string> Lines
		{
			get
			{
				return _lines;
			}
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			if (_binReader != null)
				_binReader.Close();
			if (_streamReader != null)
			{
				_streamReader.Close();
				_streamReader.Dispose();
			}
			if (_fileStream != null)
			{
				_fileStream.Close();
				_fileStream.Dispose();
			}
		}
		~TextFileReader()
		{
			this.Dispose();
		}
	}
