    public struct PaddedString : IFormattable
    {
       private string value;
       public PaddedString(string value) { this.value = value; }
       public string ToString(string format, IFormatProvider formatProvider)
       { 
          //... use the format to pad value
       }
       public static explicit operator PaddedString(string value)
       {
         return new PaddedString(value);
       }
    }
