    public delegate void SubscriptionHandler<T>(string name, T handler);
    
    public class SomePresenterTest
    {
        [Test]
        public void Subscription_Test()
        {
            var someServiceMock = new Mock<ISomeDomainService>();
            var viewMock = new Mock<IView>();
            //Setup your viewMock here
            var someView = new FakeView(viewMock.Object);
            EventHandler initHandler = null;            
            someView.Subscription += (n, h) => { if ((nameof(someView.Init)).Equals(n)) initHandler=h; };
            Assert.IsNull(initHandler);
            var presenter = new SomePresenter(someServiceMock.Object, someView);
            Assert.IsNotNull(initHandler);
            Assert.AreEqual("OnInit", initHandler?.Method.Name);
        }
    }
