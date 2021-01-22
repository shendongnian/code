    public class WorkContainer:Dictionary<string, object>
    {
        public T GetKeyValue<T>(string Parameter) 
        {
            if (Parameter.StartsWith("[? "))
            {
                string key = Parameter.Replace("[? ", "").Replace(" ?]", "");
                if (this.ContainsKey(key))
                {
                    if (typeof(T) == typeof(string) )
                    {
                        // Special Case for String, especially if the object is a class
                        // Take the ToString Method not implicit conversion
                        return (T)Convert.ChangeType(this[key].ToString(), typeof(T));
                    }
                    else
                    {
                        return (T)this[key];
                    }
                }
                else
                {
                    return default(T);
                }
               
            }
            else
            {                
                return (T)Convert.ChangeType(Parameter, typeof(T));
            }
        }
    }
