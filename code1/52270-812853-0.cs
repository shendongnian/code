	[TestFixture]
	public class EnumParsingSO
	{
		public enum Days
		{
			Sat = 1,
			Sun,
			Mon,
			Tues
		}
		[Test]
		public void EnumFromString()
		{
			Days expected = Days.Mon;
			int expectedInt = 3;
			Days actual = (Days)Enum.Parse(typeof(Days), "Mon");
			Assert.AreEqual(expected, actual);
			Assert.AreEqual(expectedInt, (int)actual);
		}
	}
