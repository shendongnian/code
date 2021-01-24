	[TestClass]
	public class BookTest 
	{
		private FakeBooksDbContext context;
		
		[TestInitialize]
		public void Init()
		{
			context = new FakeBooksDbContext();
		}
		
		[TestMethod]
		public void When_PriceIs10_Then_X()
		{
			// Arrange
			SetupFakeData(10);
			
			// Act
			
			// Assert
		}
		
		private void SetupFakeData(int price) 
		{
			context.Books.Add(new Book { Price = price });
		}
	}
