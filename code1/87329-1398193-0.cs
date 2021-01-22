    using System; 
    using System.Globalization;
    class DateAndTimeFormatting 
    {
      static DateTime dt = DateTime.Now; 
      static void Main()
      {
        ShowFormatting(DateTimeFormatInfo.InvariantInfo, "InvariantInfo"); 
        ShowFormatting(DateTimeFormatInfo.CurrentInfo, "CurrentInfo"); 
      }
      static void ShowFormatting(DateTimeFormatInfo format, string strLabel) 
      {
        Console.WriteLine(strLabel);
        Console.WriteLine(new string('-', strLabel.Length)); 
        string[] strFormats = {"d", "D", "f", "F", "g", "G", "m", "r", "s", "t", "T", "u", "U", "y" }; 
        foreach (string strFormat in strFormats) 
           Console.WriteLine("{0}: {1}", strFormat, dt.ToString(strFormat, format)); 
        Console.WriteLine();
      }
    }
