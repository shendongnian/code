		[Test]
		public void TableTest()
		{
			try
			{
				Assert.AreEqual("value that should be in the cell", selenium.GetTable("table.1.2"));
			}
			catch (AssertionException e)
			{
				verificationErrors.Append(e.Message);
			}
		}
