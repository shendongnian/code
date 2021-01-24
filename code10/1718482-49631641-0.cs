		[TearDown]
		public void TearDown()
		{
			if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
			{
				Log.Save(TestContext.CurrentContext.Result.Message);
			}
		}
		[Test]
		public void AssertMultipleTest()
		{
			Assert.Multiple(() =>
			{
				Assert.That(true, Is.False);
				Assert.That(7, Is.Zero);
			});
		}
