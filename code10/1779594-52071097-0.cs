	public static void Main()
	{
		var json1 = @"{'Test':[{ "+
						"'Cust-no':'00000001', "+
						"'Cust-status':'555', "+
						"'Last-update':'1999-08-17'} "+ 
						"]}";
		
		var json2 = @"{'Test':[{ "+
						"'Cust-no':'00000001', "+
						"'Cust-status':'666', "+
						"'Last-update':'2018-08-17'} "+ 
						"]}";
		
		JObject obj1 = JsonConvert.DeserializeObject<JObject>(json1);
   		JObject obj2 = JsonConvert.DeserializeObject<JObject>(json2);
		
		if (JToken.DeepEquals(obj1, obj2))
		{
			Console.WriteLine("Both Objects are same.");
			return;
		}
		
		
		// create another JObject thats points to your actual first element in 'Test' node from your json.
		JObject obj1Data = obj1.GetValue("Test")[0] as JObject;
		JObject obj2Data = obj2.GetValue("Test")[0] as JObject;
		
		var lst = new List<string>();				
		
		foreach (KeyValuePair<string, JToken> obj1Prop in obj1Data)
     	{
		  JProperty obj2Prop = obj2Data.Property(obj1Prop.Key);
		  if (!JToken.DeepEquals(obj1Prop.Value, obj2Prop.Value))
          {
			  lst.Add(obj1Prop.Key);
              Console.WriteLine(string.Format("{0} property value is changed", obj1Prop.Key));
          }
          else
          {
              Console.WriteLine(string.Format("{0} property value didn't change", obj1Prop.Key));
          }
		}
		Console.WriteLine("\n\nProperty Changed - ");
		lst.ForEach(p=>Console.WriteLine(p));		
	}
