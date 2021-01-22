    public class ParameterDictionary : Dictionary<string,object>
    {
        public ParameterDictionary( object parameters )
        {
             if (parameters != null)
             {
                 foreach (PropertyInfo info in parameters.GetType()
                                                         .GetProperties())
                 {
                     object value = info.GetValue(parameters,null);
                     this.Add(info.Name,value);
                 }
             }
        }
    }
