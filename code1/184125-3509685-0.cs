		/// <summary>
		/// Defines CSV reader states
		/// </summary>
		enum State
		{
			Initial, 
			Quote,
			Data,
			NestedQuote
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="CsvReader"/> class.
		/// </summary>
		/// <param name="inputStream">The input stream.</param>
		public CsvReader(Stream inputStream)
		{
			if (inputStream == null) 
				throw new ArgumentNullException("inputStream");
			reader = new StreamReader(inputStream);
		}
		/// <summary>
		/// Reads a single line of CSV data.
		/// </summary>
		/// <returns>Array of CSV fields</returns>
		public string[] Read()
		{
			var line = reader.ReadLine();
			var retval = new List<string>();
			if (line == null) 
				return null;
			var state = State.Initial;
			var text = new StringBuilder();
			foreach (var ch in line)
				switch (state)
				{
					case State.Initial:
						if (ch == '"') 
							state = State.Quote;
						else if (ch == ',') 
							retval.Add(string.Empty);
						else
						{
							text.Append(ch);
							state = State.Data;
						}
						break;
					case State.Data:
						if (ch == ',')
						{
							retval.Add(text.ToString());
							text.Length = 0;
							state = State.Initial;
						}
						else 
							text.Append(ch);
						break;
					case State.Quote:
						if (ch == '"')
							state = State.NestedQuote;
						else 
							text.Append(ch);
						break;
					case State.NestedQuote:
						if (ch == '"')
						{
							text.Append('"');
							state = State.Quote;
							break;
						}
						state = State.Data;
						goto case State.Data;
				}
			retval.Add(text.ToString());
			return retval.ToArray();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			reader.Dispose();
		}
