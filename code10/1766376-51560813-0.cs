    public class SkipArrayConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return !objectType.IsArray;
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		JArray array = JArray.Load(reader);
    		DataTable dataTable = new DataTable();
    		int i = 0;
    		foreach (JToken token in array.Children())
    		{
    			var dataRow = dataTable.NewRow();
    			if (token.Type != JTokenType.Object) continue;
    
    			if (i == 0)
    			{
    				SetColumns(dataTable, token);
    				dataRow = dataTable.NewRow();
    				i++;
    			}
    
    			foreach (JToken jToken in token)
    			{
    				if (((JProperty)jToken).Value.Type != JTokenType.Array)
    				{
    					string name = ((JProperty)jToken).Name;
    					object value = ((JValue)((JProperty)jToken).Value).Value;
    					dataRow[name] = value;
    				}
    			}
    
    			dataTable.Rows.Add(dataRow);
    		}
    		return dataTable;
    	}
    
    	private void SetColumns(DataTable dt, JToken token)
    	{
    		foreach (JToken jToken in token)
    		{
    			if (((JProperty)jToken).Value.Type != JTokenType.Array)
    			{
    				string name = ((JProperty)jToken).Name;
    				object value = ((JValue)((JProperty)jToken).Value).Value;
    				Type valueType = value.GetType();
    				dt.Columns.Add(name, valueType);
    			}
    		}
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    }
