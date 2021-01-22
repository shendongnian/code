    class Mathematician {
		public delegate int MathMethod(int a, int b);
		public int DoMaths(int a, int b, MathMethod mathMethod) {
			return mathMethod(a, b);
		}
	}
	[Test]
	public void Test() {
		var math = new Mathematician();
		Mathematician.MathMethod addition = (a, b) => a + b;
		var method = typeof(Mathematician).GetMethod("DoMaths");
		var result = method.Invoke(math, new object[] { 1, 2, addition });
		Assert.AreEqual(3, result);
	}
