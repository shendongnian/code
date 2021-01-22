    //...
	[TestMethod]
		public void round_down()
		{
			Assert.AreEqual(-5.RoundDown(), 0);
			Assert.AreEqual(0.RoundDown(), 0);
			Assert.AreEqual(1.RoundDown(), 0);
			Assert.AreEqual(20.RoundDown(), 15);
			Assert.AreEqual(42.RoundDown(), 30);
			Assert.AreEqual(48.RoundDown(), 45);
			Assert.AreEqual(59.RoundDown(), 45);
			Assert.AreEqual(90.RoundDown(), 45);
		}
//...
    public static class Ext
	{
		public static int RoundDown(this int val)
		{
			if (val < 0)
				return 0;
			if (val < 15)
				return 0;
			if (val < 30)
				return 15;
			if (val < 45)
				return 30;
			return 45;
		}
	}
