    void Main()
    {
    	var file1 = "a,b,c\r\nx,y,z";
    	CSV.ParseText(file1).Dump();
    
    	var file2 = "a,\"b\",c\r\nx,\"y,z\"";
    	CSV.ParseText(file2).Dump();
    
    	var file3 = "a,\"b\",c\r\nx,\"y\r\nz\"";
    	CSV.ParseText(file3).Dump();
    
    	var file4 = "\"\"\"\"";
    	CSV.ParseText(file4).Dump();
    }
    
    static class CSV
    {
    	public struct Record
    	{
    		public readonly string[] Row;
    
    		public string this[int index] => Row[index];
    
    		public Record(string[] row)
    		{
    			Row = row;
    		}
    	}
    
    	public static List<Record> ParseText(string text)
    	{
    		return Parse(new StringReader(text));
    	}
    
    	public static List<Record> ParseFile(string fn)
    	{
    		using (var reader = File.OpenText(fn))
    		{
    			return Parse(reader);
    		}
    	}
    
    	public static List<Record> Parse(TextReader reader)
    	{
    		var data = new List<Record>();
    
    		var col = new StringBuilder();
    		var row = new List<string>();
    		for (; ; )
    		{
    			var ln = reader.ReadLine();
    			if (ln == null) break;
    			if (Tokenize(ln, col, row))
    			{
    				data.Add(new Record(row.ToArray()));
    				row.Clear();
    			}
    		}
    
    		return data;
    	}
    
    	public static bool Tokenize(string s, StringBuilder col, List<string> row)
    	{
    		int i = 0;
    
    		if (col.Length > 0)
    		{
    			col.AppendLine(); // continuation
    
    			if (!TokenizeQuote(s, ref i, col, row))
    			{
    				return false;
    			}
    		}
    
    		while (i < s.Length)
    		{
    			var ch = s[i];
    			if (ch == ',')
    			{
    				row.Add(col.ToString().Trim());
    				col.Length = 0;
    				i++;
    			}
    			else if (ch == '"')
    			{
    				i++;
    				if (!TokenizeQuote(s, ref i, col, row))
    				{
    					return false;
    				}
    			}
    			else
    			{
    				col.Append(ch);
    				i++;
    			}
    		}
    
    		if (col.Length > 0)
    		{
    			row.Add(col.ToString().Trim());
    			col.Length = 0;
    		}
    
    		return true;
    	}
    
    	public static bool TokenizeQuote(string s, ref int i, StringBuilder col, List<string> row)
    	{
    		while (i < s.Length)
    		{
    			var ch = s[i];
    			if (ch == '"')
    			{
    				// escape sequence
    				if (i + 1 < s.Length && s[i + 1] == '"')
    				{
    					col.Append('"');
    					i++;
    					i++;
    					continue;
    				}
    				i++;
    				return true;
    			}
    			else
    			{
    				col.Append(ch);
    				i++;
    			}
    		}
    		return false;
    	}
    }
