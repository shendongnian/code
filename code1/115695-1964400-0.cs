    using System;
    using System.Text;
    
    class Program {
      static void Main(string[] args) {
        string input = "に投稿できる";
        Console.WriteLine(EncodeTwit(input));
        Console.ReadLine();
      }
      public static string EncodeTwit(string txt) {
        var enc = Encoding.GetEncoding("iso-2022-jp");
        byte[] bytes = enc.GetBytes(txt);
        char[] chars = new char[(bytes.Length * 3 + 1) / 2];
        int len = Convert.ToBase64CharArray(bytes, 0, bytes.Length, chars, 0);
        return "=?ISO-2022-JP?B?" + new string(chars, 0, len) + "?=";
      }
    }
