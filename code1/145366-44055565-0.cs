    void Main()
    {
    	var result = Whatever((123, true));
    	Debug.Assert(result.Something == 123);
    	Debug.Assert(result.Another == "True");
    }
    
    (int Something, string Another) Whatever((int Neat, bool Cool) data)
    {
    	return (data.Neat, data.Cool.ToString());
    }
