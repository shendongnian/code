    public class PstnNumber 
    {  
       private string m_number; // always in long format
       public static PstnNumber(string s)  { ... } // accepts short and long form
       
       public string Number { get { return m_number; } }
       public string AutoFormatted { { get { ... } }
    }
