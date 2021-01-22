		[TestMethod]
		public void ShouldBeAbleToConvertAnAnonymousObjectToAnExpandoObject()
		{
			var additionalViewData = new {id = "myControlId", css = "hide well"};
			dynamic result = new ExpandoObject();
			var dict = (IDictionary<string, object>)result;
			foreach (PropertyInfo propertyInfo in additionalViewData.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
			{
				dict[propertyInfo.Name] = propertyInfo.GetValue(additionalViewData, null);
			}
			Assert.AreEqual(result.id, "myControlId");
			Assert.AreEqual(result.css, "hide well");
		}
