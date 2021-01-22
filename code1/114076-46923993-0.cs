    public class Scorekeeper { 
       int swish = 7; 
       public Action Counter(int start)
       {
          int count = 0;
          Action counter = () => { count += start + swish; }
          return counter;
       }
    }
