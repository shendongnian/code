    		System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
			string json = @"{
							  'key1': 'value1',  
							  'key2': 'value2',  
							  'key3': false,  
							  'key4': 10
							}";
			Dictionary<string, string> dic = js.Deserialize<Dictionary<string, string>>(json); // deserialize
			foreach (KeyValuePair<string,string> o in dic)
			{
				// do whatever
			}
			dic.Add("newKey", "new value"); // add an attribute
			string newjson = js.Serialize(dic);  // serialize back to string
