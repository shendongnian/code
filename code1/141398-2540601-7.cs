    /// <summary>
    /// Extension methods needed to implement Javascript dates for C#
    /// </summary>
    public static class MyExtensions{
    	public static double JavascriptTicks(this DateTime dt) {
    		DateTime d1 = new DateTime(1970, 1, 1);
    		DateTime d2 = dt.ToUniversalTime();
    		TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
    		return ts.TotalMilliseconds;
    	}        
    }
    /// <summary>
    /// Serialize a single value
    /// </summary>
    /// <param name="o">An object to serialize</param>
    /// <returns>A JSON string of the value</returns>
    if (o is string) {
        return string.Format("\"{0}\"", o);
    } else if (o is DateTime) {
        return string.Format("new Date({0})", ((DateTime)o).JavascriptTicks()); ;
    } else if(o.GetType().IsValueType) {
        return o.ToString();
    } else {
        DataContractJsonSerializer json = new DataContractJsonSerializer(o.GetType());
        using(MemoryStream ms = new MemoryStream())
        using (StreamReader sr = new StreamReader(ms)) {
            json.WriteObject(ms, o);
            ms.Position = 0;
            return sr.ReadToEnd();
        }
    }
				
    /// <summary>
    /// Serializes a List object into JSON
    /// </summary>
    /// <param name="list">The IList interface into the List</param>
    /// <returns>A JSON string of the list</returns>
    public string SerializeList(IList list) {
    	string result = null;
    	if (list != null) {
    		IEnumerator it = list.GetEnumerator();
    		StringBuilder sb = new StringBuilder();
    		long len = list.Count;
    		sb.Append("[");
    		while (it.MoveNext()) {
    			if (it.Current is IList) {
    				sb.Append(SerializeList((IList)it.Current));
    			} else if (it.Current is IDictionary) {
    				sb.Append(SerializeDictionary((IDictionary)it.Current));
    			} else {
    				sb.Append(SerializeValue(it.Current));
    			}
    			--len;
    			if (len > 0) sb.Append(",");
    		}
    		sb.Append("]");
    		result = sb.ToString();
    	}
    	return result;
    }
    /// <summary>
    /// Returns a stringified key of the object
    /// </summary>
    /// <param name="o">The key value</param>
    /// <returns></returns>
    public string SerializeKey(object o) {
    	return string.Format("\"{0}\"", o); 
    }
    /// <summary>
    /// Serializes a dictionary into JSON
    /// </summary>
    /// <param name="dict">The IDictionary interface into the Dictionary</param>
    /// <returns>A JSON string of the Dictionary</returns>
    public string SerializeDictionary(IDictionary dict) {
    	string result = null;
    	if (dict != null) {
    		IDictionaryEnumerator it = dict.GetEnumerator();
    		StringBuilder sb = new StringBuilder();
    		long len = dict.Count;
    		sb.Append("{");
    		while (it.MoveNext()) {
    			sb.Append(SerializeKey(it.Key));
    			sb.Append(":");
    			if (it.Value is IList) {
    				sb.Append(SerializeList((IList)it.Value));
    			} else if (it.Value is IDictionary) {
    				sb.Append(SerializeDictionary((IDictionary)it.Value));
    			} else {
    				sb.Append(SerializeValue(it.Value));
    			}
    			--len;
    			if (len > 0) sb.Append(",");
    		}
    		sb.Append("}");
    		result = sb.ToString();
    	}
    	return result;
    }   
