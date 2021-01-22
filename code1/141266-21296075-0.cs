    public string GetExcelColumn(int index)
    {
    	int quotient = index / 26;
    
    	if (quotient > 0)
    		return GetExcelColumn(quotient - 1) + (char)((int)'A' + (index % 26));
    	else
    		return "" + (char)((int)'A' + index);
    }
    
    static IEnumerable<string> GetExcelColumns()
    {
    	var alphabet = new string[]{""}.Union(from c in Enumerable.Range((int)'A', 26) select Convert.ToString((char)c));
    
    	return from c1 in alphabet
    			from c2 in alphabet
    			from c3 in alphabet.Skip(1)                    // c3 is never empty
    			where c1 == string.Empty || c2 != string.Empty // only allow c2 to be empty if c1 is also empty
    			select c1 + c2 + c3;
    }
