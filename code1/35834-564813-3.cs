    using System.Text;
    class Test
    {
         static void Main()
         {
             StringBuilder sb = new StringBuilder();
             int tmp = sb.Length;
             Foo(ref tmp);
             sb.Length = tmp;
         }
         static void Foo(ref int x)
         {
         }
    }
