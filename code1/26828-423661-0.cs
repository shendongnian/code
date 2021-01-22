	public Form3()
	{
		InitializeComponent();
		string userFriendlyQuery = "Company.CompanyName = 'ABC Corp' AND Product.ProductCode = 'XYZ001'";
		string[] queryConditions = userFriendlyQuery.Split(new string[]{" AND "},StringSplitOptions.None);
		int conditionsCount = queryConditions.Length;
		string itemFieldFriendlyQuery = string.Join(" OR ", 
			queryConditions.Select(condition =>
				{
					var conditionA = condition.Split(new string[] { " = " }, StringSplitOptions.None);
					var left = conditionA[0];
					var leftA = left.Split('.');
					string objectName = leftA[0];
					string objectProperty = leftA[1];
					var right = conditionA[1];
					return string.Format("ObjectName = '{0}' AND ObjectProperty = '{1}' AND ObjectValue = {2}",
						objectName, objectProperty, right);
				}
			).ToArray());
		
		MessageBox.Show(itemFieldFriendlyQuery);
		// outputs: "ObjectName = 'Company' AND ObjectProperty = 'CompanyName' AND ObjectValue = 'ABC Corp' OR ObjectName = 'Product' AND ObjectProperty = 'ProductCode' AND ObjectValue = 'XYZ001'"
		
		bool isValid = fieldItemList.AsQueryable().Where(itemFieldFriendlyQuery).Count() == conditionsCount;
		MessageBox.Show(isValid.ToString());
	}	
