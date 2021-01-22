    public class MyReadOnlyBytes
    {
       private byte[] myData;
    
       public MyReadOnlyBytes(byte[] data)
       {
          myData = data;
       }
    
       public byte this[int i]
       {
          get
          {
             return myData[i];
          }
       }
    }
    
    class Program
    {
       static void Main(string[] args)
       {
          var b = File.ReadAllBytes(@"C:\Windows\explorer.exe");
          var myb = new MyReadOnlyBytes(b);
    
          Test(myb);
    
          Console.ReadLine();
       }
    
       private static void Test(MyReadOnlyBytes myb)
       {
          Console.WriteLine(myb[0]);
          myb[0] = myb[1];
          Console.WriteLine(myb[0]);
       }
    }
