    public class PolyVar {
       protected string _myValue;
    
       public PolyVar() { this._myValue = ""; }
    
       public PolyVar(string value) { this._myValue = value; }
    
       public string Value { get { return this._myValue; } set { this._myValue = value; } }
       // Override ToString() so "" + polyVar1 is correctly converted.
       public override string ToString()
       {
       	return this.Value;
       }
       
       // Create an implicit cast operator from string to PolyVar
       public static implicit operator PolyVar(string x)
       {
       	return new PolyVar( x );
       }
    }
    
    
    class Ppal {
    	static void Main()
    	{
    		PolyVar work = "data"; // in lieu of "PolyVar work = new PolyVar();"
    		string temp = "Some string data here: " + work;
    		
    		System.Console.WriteLine( temp );
    	}
    }
