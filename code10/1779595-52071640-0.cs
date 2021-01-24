    class Program
    {
    	static JArray _ja = new JArray();
    	static void Main(string[] args)
    	{
    		var json1 = "{  \"Test\": [ { \"Cust-no\": \"00000001\", \"Cust-status\": \"555\", \"Last-update\": \"1999-08-17\" } ]}";
    		var json2 = "{  \"Test\": [ { \"Cust-no\": \"00000001\", \"Cust-status\": \"666\", \"Last-update\": \"2018-08-17\" } ]}";
    		var jObject1 = JObject.Parse(json1);
    		var jObject2 = JObject.Parse(json2);
    		CompareJObjects(jObject1, jObject2);
    
    
    		Console.WriteLine(_ja.ToString());
    	}
    
    	static void CompareJObjects(JObject o1, JObject o2)
    	{
    		foreach (var prop in o1.Properties())
    		{
    			switch (prop.Value)
    			{
    				case JValue jv:
    					{
    						CompareJValues((JValue)prop.Value, (JValue)o2[prop.Name], prop.Name);
    						break;
    					}
    				case JArray ja:
    					{
    						int arrIndex = 0;
    						foreach (JObject content in ja.Children<JObject>())
    						{
    							CompareJObjects(content, ((JArray)o2[prop.Name]).Children<JObject>().ToList()[arrIndex]);
    							arrIndex++;
    						}
    						break;
    					}
    				case JObject jo:
    					{
    						CompareJObjects(jo, (JObject)o2[prop.Name]);
    						break;
    					}
    				default:
    					break;
    			}
    		}
    	}
    
    	static void CompareJValues(JValue jv1, JValue jv2, string propName)
    	{
    		var o1PropValue = jv1.Value;
    		var o2PropValue = jv2.Value;
    		if (!o1PropValue.Equals(o2PropValue))
    		{
    			_ja.Add(new JValue(propName));
    		}
    	}
    	
    }
