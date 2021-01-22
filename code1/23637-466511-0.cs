    public class SomeType {
       public int myInt  { get; set; }
    }
    
    public class AnotherType {
       public string myString { get; set; }
       public SomeType mySomeType { get; set; }
    }
    
    public class LastType {
       public SomeType mySomeType { get; set; }
       public AnotherType myAnotherType { get; set; }
    }
    
    public class UserTypes{
        static void Main()
        {
            LastType lt = new LastType();
            SomeType st = new SomeType();
            AnotherType atype = new AnotherType();
    
            st.myInt = 7;
            atype.myString = "BOB";
            atype.mySomeType = st;
            lt.mySomeType = st;
            lt.myAnotherType = atype;
    
            string xmlOutput = YourAwesomeFunction(lt);
        }
    }
        
