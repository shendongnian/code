		[TestMethod]
		public void Test()
		{
			var input = @"ProjectName\Iteration\Release1\Iteration1";
			var pattern = @"\\Iteration";
			var rgx = new Regex(pattern);
			var result = rgx.Replace(input, "", 1);
			
			Assert.IsTrue(result.Equals(@"ProjectName\Release1\Iteration1"));
		}
