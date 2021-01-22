    class F
    {
      public void X();
    
      public int X(); // Bad, trying to redefine X.
    
      class G
      {
        public string X(); // OK, different scope
      }
    }
