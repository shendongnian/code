    using System;
    public class DefaultString
    {
        private const string _default = "N/A";
        
        public DefaultString(string normal)
        {
            Value = normal;
        }
        
        private string _value = _default;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    _value = _default;
                else
                    _value = value;
            }
        }
        
        public bool IsDefault()
        {
            return Value == _default;
                
        }
        
        public override string ToString()
        {
            return Value;
        }
        
        public static implicit operator string(DefaultString defaultString)
        {
            if (defaultString == null)
                return _default;
            
            return defaultString.ToString();
        }
        
        public static implicit operator DefaultString(string normal)
        {
            return new DefaultString(normal);
        }
    }
    public class Program
    {    
        public static void Main()
        {
            DefaultString nullDefault = null;
            DefaultString nullConstructorDefault = new DefaultString(null);
            DefaultString emptyDefault = String.Empty;
            DefaultString emptyConstructorDefault = new DefaultString(String.Empty);
            DefaultString abcDefault = "abc";
            DefaultString abcConstructorDefault = new DefaultString("abcConstructor");
            
            Console.WriteLine("Default string assigned to null: " + nullDefault);
            Console.WriteLine("Default string constructed with null: " + nullConstructorDefault);
            Console.WriteLine("Default string assigned empty string: " + emptyDefault);
            Console.WriteLine("Default string constructed with empty string: " + emptyConstructorDefault);
            Console.WriteLine("Default string assigned \"abc\": " + abcDefault);
            Console.WriteLine("Default string constructed with \"abcConstructor\": " + abcConstructorDefault);
        }
    }
