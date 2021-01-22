    var o = new VendorObj();
    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(o);
    foreach (var item in userVars)
    {
    	const string propPrefix = "userVar";
    	int varNum;
    	if (int.TryParse(item.VariableName, out varNum))
    	{
    		PropertyDescriptor property = properties.Find(propPrefix + "Nbr" + varNum, true);
    		property.SetValue(o, item.VariableData);
    	}
    }
