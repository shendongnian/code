    public class CaseInsensitiveBindingList<T> : BindingList<T>
    {
        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            string stringKey = key as string;            
            bool keyIsString = stringKey != null;
            for (int i = 0; i < Count; ++i)
            {
                if (keyIsString && prop.PropertyType.IsAssignableFrom(typeof(string)))
                {
                    if (stringKey.Equals(prop.GetValue(Items[i]).ToString(), StringComparison.CurrentCulture))
                        return i;
                }
                else
                {
                    if (key.Equals(prop.GetValue(Items[i])))
                        return i;    
                }
                
            }
            return -1;
        }
    }
