    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
    	//set variables    
    	string jsonObj = System.Text.Encoding.ASCII.GetString(Row.UNSTRUCTUREDVARS.GetBlobData(0,Convert.ToInt32(Row.UNSTRUCTUREDVARS.Length)));    
    	string[] regExPattern = new string[] { "\\\\", "\\d\"\"", "\"\\[", "\"\"\\[", "\\]\"", "}}\"\"", "\"\"{", "}\"\"", ":\"{", "}\"", "\\]\"\"" };
    	string[] replacePattern = new string[] { "", "\"", "[", "[", "]", "}}", "{", "}", ":{", "},", "]," };
        
    	for (int i = 0; i<regExPattern.Length; i++)
    	{    
    		Regex rgx = new Regex(regExPattern[i]);
    		jsonObj = rgx.Replace(jsonObj, replacePattern[i]);
    	}
    	
    	Row.UNSTRUCTUREDVARS = jsonObj;
    }
