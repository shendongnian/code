        using System;
        using System.ComponentModel.DataAnnotations;
    
        public class RequiredEnumFieldAttribute: RequiredAttribute
        {
            public override bool IsValid(object value)
            {
                if (value == null)
                {
                     return false;
                }
    
                var type = value.GetType();
                return type.IsEnum && Enum.IsDefined(type, value);
            }
       }
