    public class MyObject
    {
       private string _value;
       public MyObject(string v) { _value = v; }
       public void TheCallBack() {
          Console.WriteLine(_value);
       }
    }
