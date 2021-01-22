    public class UniqueAttribute : ValidationAttribute{
    
        public UniqueAttribute(Type dataContext, ...){
            if(dataContext.IsSubClassOf(typeof(DataContext))){
                var objDataContext = Activator.CreateInstance(dataContext);
            }
        }
    
    }
