    public class Test {
      public byte[] MyProperty {get;set;}
    
      public void SetMyProperty(string text)
      {
          MyProperty = System.Text.Encoding.Unicode.GetBytes(text);
      }
    }
    
    Test test = new Test();
    test. SetMyProperty("123456789123456789");
