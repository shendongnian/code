	var myData = new JsonData{
		MyString = "some string",
		MyInt = 234,
		MyBool = true,
		MyIntArray = new[] {1,2,3}
	};
	string jsonString = JsonConvert.SerializeObject(myData);
	//sending data through internet as json string
	var newData = JsonConvert.DeserializeObject<JsonData>(jsonString);
	Debug.Log(newData.MyString);
	Debug.Log(newData.MyInt);
	Debug.Log(newData.MyBool);
	Debug.Log(newData.MyIntArray);
    
