    public static class EnumerationExtension
    {
        public static string Description( this Enum value )
        {
            // get attributes  
            var field = value.GetType().GetField( value.ToString() );
            var attributes = field.GetCustomAttributes( typeof( DescriptionAttribute ), false );
            // return description
            return attributes.Any() ? ( (DescriptionAttribute)attributes.ElementAt( 0 ) ).Description : "Description Not Found";
        }
    }
