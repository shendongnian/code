        [Test]
        [GenericTestCase(typeof(IMailService), typeof(MailService))]
        [GenericTestCase(typeof(ILogger), typeof(Logger))]
        public void ValidateResolution<TQuery>(Type type)
        {
            // arrange
            var sut = new AutoFacMapper();
            // act
            sut.RegisterMappings();
            var container = sut.Build();
            // assert
            var item = sut.Container.Resolve<TQuery>();
            Assert.AreEqual(type, item.GetType());
        }
