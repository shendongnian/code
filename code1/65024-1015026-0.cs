    public abstract class Case
    {
        public abstract string ModifyString(string value);
    }
    
    public class UpperCase : Case
    {
        public override string ModifyString( string value )
        { 
            return String.ToUpper( value ); 
        }
    }
