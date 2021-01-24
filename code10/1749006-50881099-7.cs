    sealed class Term : ParseTree 
    {
    	public string Value { get; private set; }
    	public Term(string value) { this.Value = value; }
    	public override string ToString() { return this.Value; }
    }
    sealed class Additive : ParseTree 
    { 
    	public ParseTree Term { get; private set; }
    	public ParseTree Prime { get; private set; }
    	public Additive(ParseTree term, ParseTree prime) {
    		this.Term = term;
    		this.Prime = prime;
    	}
    	public override string ToString() { return "" + this.Term + this.Prime; }
    }
    sealed class AdditivePrime : ParseTree 
    { 
    	public string Operator { get; private set; }
    	public ParseTree Term { get; private set; }
    	public ParseTree Prime { get; private set; }
    	public AdditivePrime(string op, ParseTree term, ParseTree prime) {
    		this.Operator = op;
    		this.Term = term;
    		this.Prime = prime;
    	}
    	public override string ToString() { return this.Operator + this.Term + this.Prime; }
    }
    sealed class Nil : ParseTree 
    {
    	public override string ToString() { return ""; }
    }
