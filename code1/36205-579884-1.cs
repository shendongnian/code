	var strFileData = System.IO.File.ReadAllText("FileName.data");
	var jss = new JavaScriptSerializer();
	var objItemsList = jss.Deserialize<List<ConfigurationItem>>(strFileData);
	// {insert code here tomanipulate object "objItemsList"}
	var strNewData = jss.Serialize(objItemsList);
	System.IO.File.WriteAllText("FileName.data", strNewData);
