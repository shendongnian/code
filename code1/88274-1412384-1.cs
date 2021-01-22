    //class with type arguments
    public class MadLib<W> {
       public void addWord(W word) {
          System.Console.WriteLine("bob likes to " + word + " with his friends");
       }
    }
    
    
    //class with type arguments and contraints (note i'm not inheriting nothin)
    public class MadLib<W> where W:Verb{
       public void addWord(W word) {
          System.Console.WriteLine("bob likes to " + word + " with his friends");
       }
    }
