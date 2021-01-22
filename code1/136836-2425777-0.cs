    [Test]
    public void TestOfDateTime()
    {
         var mock = new Mock<IDateTime>();
         mock.Setup(fake => fake.Now)
             .Returns(new DateTime(2000, 1, 1));
    
         var result = new UnderTest(mock.Object).CalculateSomethingBasedOnDate();
    }
    public class DateTimeWrapper : IDateTime
    {
          public DateTime Now { get { return DateTime.Now; } }
    }
