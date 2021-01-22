    public object GetDynamicSortProperty(object item, string propName)
        {
            try
            {                 
                string[] prop = propName.Split('.'); 
               
                //Use reflection to get order type                   
                int i = 0;                    
                while (i < prop.Count())
                {
                    item = item.GetType().GetProperty(prop[i]).GetValue(item, null);
                    i++;
                }                     
                
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        } 
