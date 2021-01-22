    public partial class MYENTITY
    {
        partial void OnValidateCustomization();
    
        public void OnValidate(System.Data.Linq.ChangeAction action)    
        {        
            if(action != System.Data.Linq.ChangeAction.Delete)        
            {            
                //hook for code generator
            }   
            OnValidateCustomization();
        }
    }
