    [TestFixture()]
	public class TestHole 
	{
			        
		private Hole _unitUnderTest;
			        
		[SetUp()]
		public void SetUp() 
		{
			_unitUnderTest = new Hole();
		}
			        
		[TearDown()]
		public void TearDown() 
		{
			_unitUnderTest = null;
		}
	
		[Test]
		public void TestConstructorHole()
		{
			Hole testHole = new Hole();
			Assert.IsNotNull(testHole, "Constructor of type, Hole failed to create instance.");
		}
	
		[Test]
		public void TestNotifyPropertyChanged()
		{
			string info = null;
			_unitUnderTest.NotifyPropertyChanged(info);
		}
	}
