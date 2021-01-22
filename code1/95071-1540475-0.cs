     public void Validate( object obj )
     {
           foreach (var property in obj.GetType().GetProperties())
           {
                var attribute = property.GetCustomAttributes(typeof(ValidationAttribute), false);
                var validator = ValidationFactory.GetValidator( attribute );
                validator.Validate( property.GetValue( obj, null ) );
           }
     }
