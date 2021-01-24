    public static class Base95Extension
    {
       private const string PrintableChars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ !?\"'`^#$%@&*+=/.,:;|\\_<>[]{}()~-";
    
       private const int Length = 95;
    
       public static uint ToUInt32(this IPAddress ip)
       {
          return BitConverter.ToUInt32(ip.GetAddressBytes(), 0);
       }
    
       public static IPAddress ToIpAddress(this uint source)
       {
          return new IPAddress(BitConverter.GetBytes(source));
       }
    
       public static string ToBase95(this IPAddress ip)
       {
          var num = ip.ToUInt32();
          var result = string.Empty;
          uint index = 0;
    
          while (num >= Math.Pow(Length, index))
          {
             index++;
          }
    
          while (index-- > 0)
          {
             var pow = (uint)Math.Pow(Length, index);
             var div = num / pow;
             result += PrintableChars[(int)div];
             num -= pow * div;
          }
    
          return result;
       }
    
       public static IPAddress ToIpAddress(this string s)
       {
          uint result = 0;
    
          var chars = s.Reverse()
                       .ToArray();
    
          for (var i = 0; i < chars.Length; i++)
          {
             var pow = Math.Pow(Length, i);
             var ind = PrintableChars.IndexOf(chars[i]);
             result += (uint)(pow * ind);
          }
    
          return new IPAddress(BitConverter.GetBytes(result));
       }
    
    }
