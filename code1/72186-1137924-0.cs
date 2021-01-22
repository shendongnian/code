		public void SetDocumentProperty(string propertyName, string propertyValue)
		{
			object oDocCustomProps = workBk.CustomDocumentProperties;
			Type typeDocCustomProps = oDocCustomProps.GetType();
			object[] oArgs = {propertyName,false,
                     MsoDocProperties.msoPropertyTypeString,
                     propertyValue};
			typeDocCustomProps.InvokeMember("Add", BindingFlags.Default |
									   BindingFlags.InvokeMethod, null,
									   oDocCustomProps, oArgs);
		}
		private object GetDocumentProperty(string propertyName, MsoDocProperties type)
		{
			object returnVal = null;
			object oDocCustomProps = workBk.CustomDocumentProperties;
			Type typeDocCustomProps = oDocCustomProps.GetType();
			object returned = typeDocCustomProps.InvokeMember("Item", 
										BindingFlags.Default |
									   BindingFlags.GetProperty, null,
									   oDocCustomProps, new object[] { propertyName });
			Type typeDocAuthorProp = returned.GetType();
			returnVal = typeDocAuthorProp.InvokeMember("Value",
									   BindingFlags.Default |
									   BindingFlags.GetProperty,
									   null, returned,
									   new object[] { }).ToString();
			return returnVal;
		}
