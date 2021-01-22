    public class Test
    {
       int _number = -1;
    
       public Test() {}
       public string NumberAsString
       {
           get { return _number.ToString(); }
       }
       public int Number
       {
           get { return _number; }
           set { _number= value; }
       }
    }
