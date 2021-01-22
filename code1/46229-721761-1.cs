    	[TestFixture]
	public class ObjectExtensionsTest
	{
		private class MockClass
		{
			public MockClass()
			{
				Nested = new NestedMockClass();
			}
			public string Id { get; set; }
			public string Name { get; set; }
			public string GetOnly { get { return "MockClass"; } }
			public string SetOnly { set { } }
			public NestedMockClass Nested { get; set; }
		}
		private class NestedMockClass
		{
			public string NestedId { get; set; }
			public string NestedName { get; set; }
			public string NestedGetOnly { get { return "NestedMockClass"; } }
			public string NestedSetOnly { set { } }
		}
		[Test]
		public void TestShouldFindProperty()
		{
			MockClass mockObject = new MockClass();
			Assert.IsTrue(mockObject.HasProperty("Id"));
			Assert.IsTrue(mockObject.HasProperty("Name"));
			Assert.IsTrue(mockObject.HasProperty("GetOnly"));
			Assert.IsTrue(mockObject.HasProperty("SetOnly"));
			Assert.IsTrue(mockObject.HasProperty("Nested"));
			Assert.IsTrue(mockObject.HasProperty("Nested.NestedId"));
			Assert.IsTrue(mockObject.HasProperty("Nested.NestedName"));
			Assert.IsTrue(mockObject.HasProperty("Nested.NestedGetOnly"));
			Assert.IsTrue(mockObject.HasProperty("Nested.NestedSetOnly"));
		}
		[Test]
		public void TestShouldGetPropertyValue()
		{
			MockClass mockObject = new MockClass();
			mockObject.Id = "1";
			mockObject.Name = "Name";
			mockObject.Nested.NestedId = "NestedId";
			mockObject.Nested.NestedName = "NestedName";
			Assert.AreEqual(mockObject.Id, mockObject.GetPropertyValue("Id"));
			Assert.AreEqual(mockObject.Name, mockObject.GetPropertyValue("Name"));
			Assert.AreEqual(mockObject.GetOnly, mockObject.GetPropertyValue("GetOnly"));
			Assert.AreEqual(mockObject.Nested.NestedId, mockObject.GetPropertyValue("Nested.NestedId"));
			Assert.AreEqual(mockObject.Nested.NestedName, mockObject.GetPropertyValue("Nested.NestedName"));
		}
		[Test]
		public void TestShouldSetPropertyValue()
		{
			MockClass mockObject = new MockClass();
			mockObject.SetPropertyValue("Id", "1");
			mockObject.SetPropertyValue("Name", "Name");
			mockObject.SetPropertyValue("Nested.NestedId", "NestedId");
			mockObject.SetPropertyValue("Nested.NestedName", "NestedName");
			Assert.AreEqual(mockObject.Id, "1");
			Assert.AreEqual(mockObject.Name, "Name");
			Assert.AreEqual(mockObject.Nested.NestedId, "NestedId");
			Assert.AreEqual(mockObject.Nested.NestedName, "NestedName");
		}
	}
