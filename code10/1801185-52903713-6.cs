    public class SomeClass
    {
       public int P1 { get; set; }
       public int P2 { get; set; }
       public int P3 { get; set; }
       public int P4 { get; set; }
       public int P5 { get; set; }
    
       public int this[int i]
       {
          get {
             switch (i)
             {
                case 0: return P1;
                case 1: return P2;
                case 2: return P3;
                case 4: return P5;
             }
          }
          set
          {
             switch (i)
             {
                case 0: P1 = value;  break;
                case 1: P2 = value; break;
                case 2: P3 = value;  break;
                case 4: P4 = value; break;
             }
          }
       }
    }
    ...
    SomeClass[2] // access like an array
