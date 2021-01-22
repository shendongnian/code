    abstract class A // A is not instantiatable due to being abstract
    {
        private string m_hello = null;
    
        public string Hello
        {
             get{return m_hello;}
             set{m_hello = value;}
        }
    }
    
    class B : A
    {
        // B now cannot access the private variable, use B in your code instead of A
    }
