    public class MyClass
    {
        int myVar = 1;
        public int MyVar
        {
            get { return myVar; }
            set 
            { 
                if( value < 1 || value > 4) throw new Exception();
                myValue = value; 
            }
    
        }
    }
