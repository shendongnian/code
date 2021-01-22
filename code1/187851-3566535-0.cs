    IEnumerable<string> Parse(string input)
    {
    	const char tokenlimiter = ',';
    	const char funcstart = '#';
    	const char funcend = ')';
    	StringBuilder token = new StringBuilder(5);
    	bool gotfunc = false;
    	bool gotone = false;
    	int pos = 0;
    	int opened = 0;
    	int closed = 0;
    	foreach(char c in input)
    	{
    		if (c == funcstart)
    		{
    			gotfunc = true;
    			opened++;
    		}
    		if(c == funcend)
    		{
    			gotfunc = false;
    			closed++;
    		}
    		if(!gotfunc && c == tokenlimiter)
    		{
    			gotone = true;
    			if(token.Length == 0)
    			{
    				throw new ArgumentException("Blank instruction at " + pos, input);
    			}
    			yield return token.ToString();
    		}
    		if(gotone)
    		{
    			token = new StringBuilder(5);
    			gotone = false;
    		}
    		else
    		{
    			token.Append(c);    
    		}
    		if(pos == input.Length - 1)
    		{
    			if (!gotfunc && opened == closed && c != tokenlimiter)
    			{
    				yield return token.ToString();
    			}
    			else if (gotfunc || opened != closed)
    			{
    				throw new ArgumentException("Broken function", input);
    			}
    			else
    			{
    				throw new ArgumentException("Blank instruction at " + pos, input);
    			}
    		}
    		pos++;
    	}
    
    }
