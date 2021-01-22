        [Test]
        [TestCase(default(IMailService), typeof(MailService))]
        [TestCase(default(ILogger), typeof(Logger))]
        public void ValidateResolution<TQuery>(TQuery _, Type type)
        {
            // Arrange
            var sut = new ContainerInitalizer();
            var builder = new ContainerBuilder();
            // Act
            ContainerInitalizer.Initialize(builder);
            var container = builder.Build();
            var item = container.Resolve<TQuery>();
            // Assert
            Assert.AreEqual(type, item.GetType());
        }
