    //The Method declaration of T type
    private IdNameVM  HydrateEntityToVM<T>(T projectValue)
    {
         //Checking whether the object exists or not
         //if null than return the default value of IdNameVM
         if(projectValue == null) return default(IdNameVM);  
    
         //Checking if we are supporting the implementation or not for that class
         //In your case YourStrongTypeClass is ProjectValue Class
         if(projectValue is YourStrongTypeClass) 
         {
             
             //Casting the T object to strong type object
             var obj = projectValue as YourStrongTypeClass;
             
             return new IdNameVM()
             {
                Id = obj.Id,
                Name = obj.Name
             };
         } 
         else
         {
            //The else statement is for if you want to handle some other type of T implementation
            throw new NotImplementedException($"The type {typeof(T)} is not implemented");
         }
    }
 
