    using System;
    using System.Text;
    
    class Program {
      static void Main(string[] args) {
        uint utf32 = uint.Parse("1D0EC", System.Globalization.NumberStyles.HexNumber);
        string s = Encoding.UTF32.GetString(BitConverter.GetBytes(utf32));
        foreach (char c in s.ToCharArray()) {
          Console.WriteLine("{0:X}", (uint)c);
        }
        Console.ReadLine();
      }
    }
