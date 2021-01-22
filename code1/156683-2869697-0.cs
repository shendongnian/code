    public class SiteCache
    {
        public static T Retrieve<T>(Delegate d, params object[] methodParameters)
        {
            string key = d.Method.ReflectedType + "#" + d.Method.Name;
            for (int i = 0; i < methodParameters.Length; i++)
            {
                key += methodParameters[i].ToString();
            }
            object retVal = Get(key);
            if (retVal == null)
            {
                retVal = d.DynamicInvoke(methodParameters);
                Set(key, retVal);
            }
            return (T) retVal;
        }
        // the rest of your class goes here
