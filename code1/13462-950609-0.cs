		//This URL not exist, it's only an example.
		string url = "http://myBox.s3.amazonaws.com/";
		//Instantiate new CustomWebRequest class
		CustomWebRequest wr = new CustomWebRequest(url);
		//Set values for parameters
		wr.ParamsCollection.Add(new ParamsStruct("key", "${filename}"));
		wr.ParamsCollection.Add(new ParamsStruct("acl", "public-read"));
		wr.ParamsCollection.Add(new ParamsStruct("success_action_redirect", "http://www.yahoo.com"));
		wr.ParamsCollection.Add(new ParamsStruct("x-amz-meta-uuid", "14365123651274"));
		wr.ParamsCollection.Add(new ParamsStruct("x-amz-meta-tag", ""));
		wr.ParamsCollection.Add(new ParamsStruct("AWSAccessKeyId", "zzzz"));            
		wr.ParamsCollection.Add(new ParamsStruct("Policy", "adsfadsf"));
		wr.ParamsCollection.Add(new ParamsStruct("Signature", "hH6lK6cA="));
		//For file type, send the inputstream of selected file
		StreamReader sr = new StreamReader(@"file.txt");
		wr.ParamsCollection.Add(new ParamsStruct("file", sr, ParamsStruct.ParamType.File, "file.txt"));
		wr.PostData();
