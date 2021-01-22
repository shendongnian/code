    [DataContract]
    public class Foo
    {
       [DataMember]
       private string bar;
       public string GetBar()
       {
          return bar;
       }
       public void SetBar(string b)
       {
          bar = b;
       }
    }
