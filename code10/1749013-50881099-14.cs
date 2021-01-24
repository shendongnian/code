    sealed class Binary : ParseTree 
    {
    	public ParseTree Left { get; private set; }
    	public string Operator { get; private set; }
    	public ParseTree Right { get; private set; }
    	public Binary(ParseTree left, string op, ParseTree right) 
    	{
    		this.Left = left; 
    	    this.Operator = op;
    		this.Right = right;
    	}
    	public override string ToString() 
    	{
    		return "(" + Left + Operator + Right + ")";
    	}
    }
