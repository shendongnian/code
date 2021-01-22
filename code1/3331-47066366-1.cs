    class SqlStatementReader
    {
    	public class SqlBadSyntaxException : Exception
    	{
    		public SqlBadSyntaxException(string description) : base(description) { }
    		public SqlBadSyntaxException(string description, int line) : base(OnBase(description, line, null)) { }
    		public SqlBadSyntaxException(string description, int line, string filePath) : base(OnBase(description, line, filePath)) { }
    		private static string OnBase(string description, int line, string filePath)
    		{
    			if (filePath == null)
    				return string.Format("Line: {0}. {1}", line, description);
    			else
    				return string.Format("File: {0}\r\nLine: {1}. {2}", filePath, line, description);
    		}
    	}
    
    	enum SqlScriptChunkTypes
    	{
    		InstructionOrUnquotedIdentifier = 0,
    		BracketIdentifier = 1,
    		QuotIdentifierOrLiteral = 2,
    		DblQuotIdentifierOrLiteral = 3,
    		CommentLine = 4,
    		CommentMultiline = 5,
    	}
    
    	StreamReader _sr = null;
    	string _filePath = null;
    	int _lineStart = 1;
    	int _lineEnd = 1;
    	bool _isNextChar = false;
    	char _nextChar = '\0';
    
    	public SqlStatementReader(StreamReader sr)
    	{
    		if (sr == null)
    			throw new ArgumentNullException("StreamReader can't be null.");
    
    		if (sr.BaseStream is FileStream)
    			_filePath = ((FileStream)sr.BaseStream).Name;
    
    		_sr = sr;
    	}
    
    	public SqlStatementReader(StreamReader sr, string filePath)
    	{
    		if (sr == null)
    			throw new ArgumentNullException("StreamReader can't be null.");
    
    		_sr = sr;
    		_filePath = filePath;
    	}
    
    	public int LineStart { get { return _lineStart; } }
    	public int LineEnd { get { return _lineEnd == 1 ? _lineEnd : _lineEnd - 1; } }
    
    	public void LightSyntaxCheck()
    	{
    		while (ReadStatementInternal(true) != null) ;
    	}
    
    	public string ReadStatement()
    	{
    		for (string s = ReadStatementInternal(false); s != null; s = ReadStatementInternal(false))
    		{
    			// skip empty
    			for (int i = 0; i < s.Length; i++)
    			{
    				switch (s[i])
    				{
    					case ' ': continue;
    					case '\t': continue;
    					case '\r': continue;
    					case '\n': continue;
    					default:
    						return s;
    				}
    			}
    		}
    		return null;
    	}
    
    	string ReadStatementInternal(bool syntaxCheck)
    	{
    		if (_isNextChar == false && _sr.EndOfStream)
    			return null;
    
    		StringBuilder allLines = new StringBuilder();
    		StringBuilder line = new StringBuilder();
    		SqlScriptChunkTypes nextChunk = SqlScriptChunkTypes.InstructionOrUnquotedIdentifier;
    		SqlScriptChunkTypes currentChunk = SqlScriptChunkTypes.InstructionOrUnquotedIdentifier;
    		char ch = '\0';
    		int lineCounter = 0;
    		int nextLine = 0;
    		int currentLine = 0;
    		bool nextCharHandled = false;
    		bool foundGO;
    		int go = 1;
    
    		while (ReadChar(out ch))
    		{
    			if (nextCharHandled == false)
    			{
    				currentChunk = nextChunk;
    				currentLine = nextLine;
    
    				switch (currentChunk)
    				{
    					case SqlScriptChunkTypes.InstructionOrUnquotedIdentifier:
    
    						if (ch == '[')
    						{
    							currentChunk = nextChunk = SqlScriptChunkTypes.BracketIdentifier;
    							currentLine = nextLine = lineCounter;
    						}
    						else if (ch == '"')
    						{
    							currentChunk = nextChunk = SqlScriptChunkTypes.DblQuotIdentifierOrLiteral;
    							currentLine = nextLine = lineCounter;
    						}
    						else if (ch == '\'')
    						{
    							currentChunk = nextChunk = SqlScriptChunkTypes.QuotIdentifierOrLiteral;
    							currentLine = nextLine = lineCounter;
    						}
    						else if (ch == '-' && (_isNextChar && _nextChar == '-'))
    						{
    							nextCharHandled = true;
    							currentChunk = nextChunk = SqlScriptChunkTypes.CommentLine;
    							currentLine = nextLine = lineCounter;
    						}
    						else if (ch == '/' && (_isNextChar && _nextChar == '*'))
    						{
    							nextCharHandled = true;
    							currentChunk = nextChunk = SqlScriptChunkTypes.CommentMultiline;
    							currentLine = nextLine = lineCounter;
    						}
    						else if (ch == ']')
    						{
    							throw new SqlBadSyntaxException("Incorrect syntax near ']'.", _lineEnd + lineCounter, _filePath);
    						}
    						else if (ch == '*' && (_isNextChar && _nextChar == '/'))
    						{
    							throw new SqlBadSyntaxException("Incorrect syntax near '*'.", _lineEnd + lineCounter, _filePath);
    						}
    						break;
    
    					case SqlScriptChunkTypes.CommentLine:
    
    						if (ch == '\r' && (_isNextChar && _nextChar == '\n'))
    						{
    							nextCharHandled = true;
    							currentChunk = nextChunk = SqlScriptChunkTypes.InstructionOrUnquotedIdentifier;
    							currentLine = nextLine = lineCounter;
    						}
    						else if (ch == '\n' || ch == '\r')
    						{
    							currentChunk = nextChunk = SqlScriptChunkTypes.InstructionOrUnquotedIdentifier;
    							currentLine = nextLine = lineCounter;
    						}
    						break;
    
    					case SqlScriptChunkTypes.CommentMultiline:
    
    						if (ch == '*' && (_isNextChar && _nextChar == '/'))
    						{
    							nextCharHandled = true;
    							nextChunk = SqlScriptChunkTypes.InstructionOrUnquotedIdentifier;
    							nextLine = lineCounter;
    						}
    						else if (ch == '/' && (_isNextChar && _nextChar == '*'))
    						{
    							throw new SqlBadSyntaxException("Missing end comment mark '*/'.", _lineEnd + currentLine, _filePath);
    						}
    						break;
    
    					case SqlScriptChunkTypes.BracketIdentifier:
    
    						if (ch == ']')
    						{
    							nextChunk = SqlScriptChunkTypes.InstructionOrUnquotedIdentifier;
    							nextLine = lineCounter;
    						}
    						break;
    
    					case SqlScriptChunkTypes.DblQuotIdentifierOrLiteral:
    
    						if (ch == '"')
    						{
    							if (_isNextChar && _nextChar == '"')
    							{
    								nextCharHandled = true;
    							}
    							else
    							{
    								nextChunk = SqlScriptChunkTypes.InstructionOrUnquotedIdentifier;
    								nextLine = lineCounter;
    							}
    						}
    						break;
    
    					case SqlScriptChunkTypes.QuotIdentifierOrLiteral:
    
    						if (ch == '\'')
    						{
    							if (_isNextChar && _nextChar == '\'')
    							{
    								nextCharHandled = true;
    							}
    							else
    							{
    								nextChunk = SqlScriptChunkTypes.InstructionOrUnquotedIdentifier;
    								nextLine = lineCounter;
    							}
    						}
    						break;
    				}
    			}
    			else
    				nextCharHandled = false;
    
    			foundGO = false;
    			if (currentChunk == SqlScriptChunkTypes.InstructionOrUnquotedIdentifier || go >= 5 || (go == 4 && currentChunk == SqlScriptChunkTypes.CommentLine))
    			{
    				// go = 0 - break, 1 - begin of the string, 2 - spaces after begin of the string, 3 - G or g, 4 - O or o, 5 - spaces after GO, 6 - line comment after valid GO
    				switch (go)
    				{
    					case 0:
    						if (ch == '\r' || ch == '\n')
    							go = 1;
    						break;
    					case 1:
    						if (ch == ' ' || ch == '\t')
    							go = 2;
    						else if (ch == 'G' || ch == 'g')
    							go = 3;
    						else if (ch != '\n' && ch != '\r')
    							go = 0;
    						break;
    					case 2:
    						if (ch == 'G' || ch == 'g')
    							go = 3;
    						else if (ch == '\n' || ch == '\r')
    							go = 1;
    						else if (ch != ' ' && ch != '\t')
    							go = 0;
    						break;
    					case 3:
    						if (ch == 'O' || ch == 'o')
    							go = 4;
    						else if (ch == '\n' || ch == '\r')
    							go = 1;
    						else
    							go = 0;
    						break;
    					case 4:
    						if (ch == '\r' && (_isNextChar && _nextChar == '\n'))
    							go = 5;
    						else if (ch == '\n' || ch == '\r')
    							foundGO = true;
    						else if (ch == ' ' || ch == '\t')
    							go = 5;
    						else if (ch == '-' && (_isNextChar && _nextChar == '-'))
    							go = 6;
    						else
    							go = 0;
    						break;
    					case 5:
    						if (ch == '\r' && (_isNextChar && _nextChar == '\n'))
    							go = 5;
    						else if (ch == '\n' || ch == '\r')
    							foundGO = true;
    						else if (ch == '-' && (_isNextChar && _nextChar == '-'))
    							go = 6;
    						else if (ch != ' ' && ch != '\t')
    							throw new SqlBadSyntaxException("Incorrect syntax was encountered while parsing go.", _lineEnd + lineCounter, _filePath);
    						break;
    					case 6:
    						if (ch == '\r' && (_isNextChar && _nextChar == '\n'))
    							go = 6;
    						else if (ch == '\n' || ch == '\r')
    							foundGO = true;
    						break;
    					default:
    						go = 0;
    						break;
    				}
    			}
    			else
    				go = 0;
    
    			if (foundGO)
    			{
    				if (ch == '\r' || ch == '\n')
    				{
    					++lineCounter;
    				}
    				// clear GO
    				string s = line.Append(ch).ToString();
    				for (int i = 0; i < s.Length; i++)
    				{
    					switch (s[i])
    					{
    						case ' ': continue;
    						case '\t': continue;
    						case '\r': continue;
    						case '\n': continue;
    						default:
    							_lineStart = _lineEnd;
    							_lineEnd += lineCounter;
    							return allLines.Append(s.Substring(0, i)).ToString();
    					}
    				}
    				return string.Empty;
    			}
    
    			// accumulate by string
    			if (ch == '\r' && (_isNextChar == false || _nextChar != '\n'))
    			{
    				++lineCounter;
    				if (syntaxCheck == false)
    					allLines.Append(line.Append('\r').ToString());
    				line.Clear();
    			}
    			else if (ch == '\n')
    			{
    				++lineCounter;
    				if (syntaxCheck == false)
    					allLines.Append(line.Append('\n').ToString());
    				line.Clear();
    			}
    			else
    			{
    				if (syntaxCheck == false)
    					line.Append(ch);
    			}
    		}
    
    		// this is the end of the stream, return it without GO, if GO exists
    		switch (currentChunk)
    		{
    			case SqlScriptChunkTypes.InstructionOrUnquotedIdentifier:
    			case SqlScriptChunkTypes.CommentLine:
    				break;
    			case SqlScriptChunkTypes.CommentMultiline:
    				if (nextChunk != SqlScriptChunkTypes.InstructionOrUnquotedIdentifier)
    					throw new SqlBadSyntaxException("Missing end comment mark '*/'.", _lineEnd + currentLine, _filePath);
    				break;
    			case SqlScriptChunkTypes.BracketIdentifier:
    				if (nextChunk != SqlScriptChunkTypes.InstructionOrUnquotedIdentifier)
    					throw new SqlBadSyntaxException("Unclosed quotation mark [.", _lineEnd + currentLine, _filePath);
    				break;
    			case SqlScriptChunkTypes.DblQuotIdentifierOrLiteral:
    				if (nextChunk != SqlScriptChunkTypes.InstructionOrUnquotedIdentifier)
    					throw new SqlBadSyntaxException("Unclosed quotation mark \".", _lineEnd + currentLine, _filePath);
    				break;
    			case SqlScriptChunkTypes.QuotIdentifierOrLiteral:
    				if (nextChunk != SqlScriptChunkTypes.InstructionOrUnquotedIdentifier)
    					throw new SqlBadSyntaxException("Unclosed quotation mark '.", _lineEnd + currentLine, _filePath);
    				break;
    		}
    
    		if (go >= 4)
    		{
    			string s = line.ToString();
    			for (int i = 0; i < s.Length; i++)
    			{
    				switch (s[i])
    				{
    					case ' ': continue;
    					case '\t': continue;
    					case '\r': continue;
    					case '\n': continue;
    					default:
    						_lineStart = _lineEnd;
    						_lineEnd += lineCounter + 1;
    						return allLines.Append(s.Substring(0, i)).ToString();
    				}
    			}
    		}
    
    		_lineStart = _lineEnd;
    		_lineEnd += lineCounter + 1;
    		return allLines.Append(line.ToString()).ToString();
    	}
    
    	bool ReadChar(out char ch)
    	{
    		if (_isNextChar)
    		{
    			ch = _nextChar;
    			if (_sr.EndOfStream)
    				_isNextChar = false;
    			else
    				_nextChar = Convert.ToChar(_sr.Read());
    			return true;
    		}
    		else if (_sr.EndOfStream == false)
    		{
    			ch = Convert.ToChar(_sr.Read());
    			if (_sr.EndOfStream == false)
    			{
    				_isNextChar = true;
    				_nextChar = Convert.ToChar(_sr.Read());
    			}
    			return true;
    		}
    		else
    		{
    			ch = '\0';
    			return false;
    		}
    	}
    
    	public static int ExecuteSqlFile(string filePath, SqlConnection connection, Encoding fileEncoding, int commandTimeout)
    	{
    		int rowsAffected = 0;
    		using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
    		{
    			// Simple syntax check (you can comment out these two lines below)
    			new SqlStatementReader(new StreamReader(fs, fileEncoding)).LightSyntaxCheck();
    			fs.Seek(0L, SeekOrigin.Begin);
    
    			// Read statements without GO
    			SqlStatementReader rd = new SqlStatementReader(new StreamReader(fs, fileEncoding));
    			string stmt;
    			while ((stmt = rd.ReadStatement()) != null)
    			{
    				using (SqlCommand cmd = connection.CreateCommand())
    				{
    					cmd.CommandText = stmt;
    					cmd.CommandTimeout = commandTimeout;
    					int i = cmd.ExecuteNonQuery();
    					if (i > 0)
    						rowsAffected += i;
    				}
    			}
    		}
    		return rowsAffected;
    	}
    }
