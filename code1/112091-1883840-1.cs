    public class ListFormatter {
        // stores transformation delegates keyed by column name (multiple keys for each column is allowed)
    	public List<KeyValuePair<String, Func<String, String>>> Transforms = new List<KeyValuePair<String, Func<String, String>>>();
    	
        // method for tokenizing and writing back - encapsulate file format to some extent
    	public Func<String, String[]> GetTokensFromLine { get; set; }
    	public Func<IEnumerable<String>, String> GetLineFromTokens { get; set; }
    
    	public String ReservedColumnNameAnyColumn = String.Empty;
    	public String ReservedColumnNameWholeLine = "WholeLine";
    
    	public ListFormatter() {
    		// by default let's set up for '|' delimited tokens, client can overwrite however
    		GetTokensFromLine = s => { return s.Split('|'); };
    		GetLineFromTokens = l => {
    			var b = new StringBuilder();
    			for (int i = 0; i < l.Count(); i++) {
    				b.Append((i > 0) ? " | " + l.ElementAt(i) : l.ElementAt(i));
    			}
    			return b.ToString();
    		};
    	}
    
    	public void FormatList(StreamReader inStream, StreamWriter outStream) {
    		// get the column names
    		var columns = GetTokensFromLine(inStream.ReadLine());
    		// TODO - validate that every column has a name
    		// write he column header to the output
    		outStream.WriteLine(GetLineFromTokens(columns));
    		
    		// iterate through the stream
    		while (true) {
    			// get a line of text, run any transforms registered to work on the whole line
    			var line = RunTransforms(inStream.ReadLine(), GetRowTransforms());
    			if (line == null) break;
    			// get the row of tokens TODO - validate for number of tokens
    			var tokens = GetTokensFromLine(line);
    			// run transforms on the columns
    			for (var i = 0; i < tokens.Count(); i++ ) {
    				tokens[i] = RunTransforms(tokens[i], GetColumnTransforms(columns[i]));
    			}
    			// write the new line to the output
    			outStream.WriteLine(GetLineFromTokens(tokens));
    		}
    	}
    
    	/// <summary>
    	/// Gets the transforms associated with a single column value
    	/// </summary>
    	/// <param name="name">The name.</param>
    	/// <returns></returns>
    	public IEnumerable<Func<String, String>> GetColumnTransforms(string name) {
    		return from kv in Transforms where kv.Key == ReservedColumnNameAnyColumn || kv.Key == name select kv.Value;
    	}
    
    	/// <summary>
    	/// Gets the transforms associated with the whole row
    	/// </summary>
    	/// <returns></returns>
    	public IEnumerable<Func<String, String>> GetRowTransforms() {
    		return from kv in Transforms where kv.Key == ReservedColumnNameWholeLine select kv.Value;
    	}
    
    	/// <summary>
    	/// Runs the transforms on a string
    	/// </summary>
    	/// <param name="item">The item.</param>
    	/// <param name="transformList">The transform list.</param>
    	/// <returns></returns>
    	public string RunTransforms(string item, IEnumerable<Func<String, String>> transformList) {
    		if (item != null) {
    			foreach (var func in transformList) {
    				item = func(item);
    			}
    		}
    		return item;
    	}
    }
    
    // usage example
    public void FormatList() {
    	var formatter = new ListFormatter();
        // add some rules
        
    	// formats every line of text
    	formatter.Transforms.Add(new KeyValuePair<string, Func<string, string>>(formatter.ReservedColumnNameWholeLine, s => s.Trim()));
    	// format every column entry
    	formatter.Transforms.Add(new KeyValuePair<string, Func<string, string>>(formatter.ReservedColumnNameAnyColumn, s => s.Trim()));
    	// format that date
    	formatter.Transforms.Add(new KeyValuePair<string, Func<string, string>>("DDate", s => DateTime.ParseExact(s, "oldformat", CultureInfo.InvariantCulture).ToString("newformat")));
        // format
    	using (var reader = File.OpenText("infile"))
    	using(var outputStream = new StreamWriter(File.OpenWrite("outfile"))) {
    		formatter.FormatList(reader, outputStream);
    	}
    }
