	class Sut<T>
	{
		public string ReverseName()
		{
			return new string(typeof(T).Name.Reverse().ToArray());
		}
	}
	[TestFixture]
	class TestingGenerics
	{
		public IEnumerable<ITester> TestCases()
		{
			yield return new Tester<string> { Expectation = "gnirtS"};
			yield return new Tester<int> { Expectation = "23tnI" };
			yield return new Tester<List<string>> { Expectation = "1`tsiL" };
		}
		[TestCaseSource("TestCases")]
		public void TestReverse(ITester tester)
		{
			tester.TestReverse();
		}
		public interface ITester
		{
			void TestReverse();
		}
		public class Tester<T> : ITester
		{
			private Sut<T> _sut;
			public string Expectation { get; set; }
 
			public Tester()
			{
				_sut=new Sut<T>();
			}
			public void TestReverse()
			{
				Assert.AreEqual(Expectation,_sut.ReverseName());
			}
		}
	}
