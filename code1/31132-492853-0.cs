    public class Test
    {
       string _numberAsString;
       int _number = -1;
       public Test() {}
       public string NumberAsString
       {
           get { return _numberAsString; }
           set { _numberAsString= value; }
       }
       public int Number
       {
           get { return int.Parse(_numberAsString); }
           set { _numberAsString = value.ToString(); }
       }
    }
