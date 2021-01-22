    use System.Text
    public class String2 {
      Encoding Encoding 
      String Data
      public static implicit operator String(String2 source) { return source.Data }
      public static explicit operator String2(string source, Encoding encoding) {...}
    }
    
    //punctionation distinctions (' "" - _ )
    public class Word: String2{}
    //letter case and punctuations ( : , ! ? . ; )
    public class Sentence: String2{}
    
    //a multi-word non-sentence?
    public class Title: String2{}
