    // In your class
    [FieldConverter(typeof(NoValueConverter))]
    public int Number;
    // Te Converter
    public class NoValueConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
           if (from.Trim().ToUpper() == "N/A")
           		return -1; // or int.MinValue;
           else
           		return Integer.Parse(from);
        }
    
        public override string FieldToString(object fieldValue)
        {
            return fieldValue.ToString();
        }
        
    }
