    public void Example()
    {   
	//Convert an integer into a variable length byte
	int varLenVal = 480;     
	VariableLength v = new VariableLength(varLenVal);
	byte[] bytes = v.Bytes;
	//Convert a variable length byte array into an integer
	byte[] varLenByte = new byte[2]{131, 96};     
	VariableLength v = new VariableLength(varLenByte);
	int result = v.Length;
    }
