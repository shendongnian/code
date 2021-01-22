    	[TestFixture]
	public class Tests
	{
		[Test]
		public void CommonCases()
		{
			foreach (var sample in new[]
				{
					new {e = 123, s = "123"},
					new {e = 110, s = "000110"},
					new {e = -011000, s = "-011000"},
					new {e = 0, s = "0"},
					new {e = 1, s = "1"},
					new {e = -2, s = "-2"},
					new {e = -12223, s = "-12223"},
					new {e = int.MaxValue, s = int.MaxValue.ToString()},
					new {e = int.MinValue, s = int.MinValue.ToString()}
				})
			{
				Assert.AreEqual(sample.e, Impl.ToInt(sample.s));
			}
		}
		[Test]
		public void BadCases()
		{
			var samples = new[] { "1231a", null, "", "a", "-a", "-" };
			var errCount = 0;
			foreach (var sample in samples)
			{
				try
				{
					Impl.ToInt(sample);
				}
				catch(ArgumentException)
				{
					errCount++;
				}
			}
			Assert.AreEqual(samples.Length, errCount);
		}
	}
