    public class FileSizeFormatProvider : IFormatProvider, ICustomFormatter
    {
       public object GetFormat(Type formatType)
       {
          if (formatType == typeof(ICustomFormatter))
          {
             return this;
          }
    
          return null;
       }
    
       private const string fileSizeFormat = "FS";
       private const string kiloByteFormat = "KB";
       private const string megaByteFormat = "MB";
       private const string gigaByteFormat = "GB";
       private const string byteFormat = "B";
       private const Decimal oneKiloByte = 1024M;
       private const Decimal oneMegaByte = oneKiloByte * 1024M;
       private const Decimal oneGigaByte = oneMegaByte * 1024M;
    
       public string Format(string format, object arg, IFormatProvider formatProvider)
       {
          //
          // Ensure the format provided is supported
          //
          if (String.IsNullOrEmpty(format) || !(format.StartsWith(fileSizeFormat, StringComparison.OrdinalIgnoreCase) ||
                                                format.StartsWith(kiloByteFormat, StringComparison.OrdinalIgnoreCase) ||
                                                format.StartsWith(megaByteFormat, StringComparison.OrdinalIgnoreCase) ||
                                                format.StartsWith(gigaByteFormat, StringComparison.OrdinalIgnoreCase)))
          {
             return DefaultFormat(format, arg, formatProvider);
          }
    
          //
          // Ensure the argument type is supported
          //
          if (!(arg is long || arg is decimal || arg is int))
          {
             return DefaultFormat(format, arg, formatProvider);
          }
    
          //
          // Try and convert the argument to decimal
          //
          Decimal size;
    
          try
          {
             size = Convert.ToDecimal(arg);
          }
          catch (InvalidCastException)
          {
             return DefaultFormat(format, arg, formatProvider);
          }
    
          //
          // Determine the suffix to use and convert the argument to the requested size
          //
          string suffix;
    
          switch (format.Substring(0, 2).ToUpper())
          {
             case kiloByteFormat:
                size = size / oneKiloByte;
                suffix = kiloByteFormat;
                break;
             case megaByteFormat:
                size = size / oneMegaByte;
                suffix = megaByteFormat;
                break;
             case gigaByteFormat:
                size = size / oneGigaByte;
                suffix = gigaByteFormat;
                break;
             case fileSizeFormat:
                if (size > oneGigaByte)
                {
                   size /= oneGigaByte;
                   suffix = gigaByteFormat;
                }
                else if (size > oneMegaByte)
                {
                   size /= oneMegaByte;
                   suffix = megaByteFormat;
                }
                else if (size > oneKiloByte)
                {
                   size /= oneKiloByte;
                   suffix = kiloByteFormat;
                }
                else
                {
                   suffix = byteFormat;
                }
                break;
             default:
                suffix = byteFormat;
                break;
          }
    
          //
          // Determine the precision to use
          //
          string precision = format.Substring(2);
    
          if (String.IsNullOrEmpty(precision))
          {
             precision = "2";
          }
    
          return String.Format("{0:N" + precision + "}{1}", size, suffix);
       }
    
       private static string DefaultFormat(string format, object arg, IFormatProvider formatProvider)
       {
          IFormattable formattableArg = arg as IFormattable;
    
          if (formattableArg != null)
          {
             return formattableArg.ToString(format, formatProvider);
          }
    
          return arg.ToString();
       }
    }
