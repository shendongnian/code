    public enum CustomerType
        {
            Starndard = 0,
            Trade = 1
        }
    
    ddCustomerTypes.DataSource = (new Domain.CustomerType()).ToDictionary();
    ddCustomerTypes.DataBind();
    
    
    //----------------------------- Extension methods -------------------
    
    public static IList<KeyValuePair<string, object>> ToList(this Enum enumObject)
    {
        Array Evalues = Enum.GetValues(enumObject.GetType());
    
         List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
    
         foreach (object value in Evalues)
         {
             list.Add(new KeyValuePair<string, object>(Enum.GetName(enumObject.GetType(), value), value));
         }
    
         return list;
    }
       
    
     public static Dictionary<string, object> ToDictionary(this Enum enumeration)
     {
         Array Evalues =  Enum.GetValues(enumeration.GetType());
    
         Dictionary<string, object> dictionary = new Dictionary<string, object>();
    
         foreach (object value in Evalues)
         {
             dictionary.Add(Enum.GetName(enumeration.GetType(), value), value);
         }
    
         return dictionary;
     }  
 
