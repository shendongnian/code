    public class SerialNumberValidatorFactory
    {
        public static SerialNumberValidatorFactory newInstance(
               ProductCategory productCategory)
        {
            switch (productCategory)
            {
                case ProductCategory.Modem:
                    return new ModemValidatorFactory();
                ....
            }
        }
        
        public abstract ISerialNumberValidator createValidator();
    }
    
    public class ModemValidatorFactory extends SerialNumberValidatorFactory
    {
       public ISerialNumberValidator createValidator() 
       {
          return new ModemSerialNumberValidator("model", "number");
       }
    }
    
    ISerialNumberValidator = SerialNumberValidatorFactory.newInstance(productCategory).createValidator()
