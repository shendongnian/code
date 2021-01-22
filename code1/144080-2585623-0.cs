        public class CastableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
            {
                public TOut GetValueAs<TOut>(TKey key) where TOut : TValue
                {
                    TValue result;
                    if (this.TryGetValue(key, out result))
                    {
                        return (TOut)result;
                    }
                    return default(TOut);
                }
            }
    
            
    
    var d = new CastableDictionary<string, object>();
    
            d.Add("A", 1);
    
            d.Add("B", new List<int>() { 1, 2, 3});
    
            var a = d.GetValueAs<int>("A"); // = 1
    
            var b = d.GetValueAs<List<int>>("B"); //= 1, 2, 3 
