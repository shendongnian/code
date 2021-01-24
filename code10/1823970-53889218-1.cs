        public class WhenInstallingEmailComponents : SpecificationBase
        {
            private IWindsorContainer _sut;
            protected override void Given()
            {
                _sut = new WindsorContainer();
            }
            protected override void When()
            {
                _sut.Install(new EmailInstaller());
            }
            [Then]
            public void ShouldConfigureEmailSender()
            {
                var handler = _sut
                    .GetHandlersFor(typeof(ISendEmail))
                    .Single(imp => imp.ComponentModel.Implementation == typeof(EmailSender));
                Assert.That(handler, Is.Not.Null);
            }
            [Then]
            public void ShouldConfigureEmailGenerator()
            {
                var handler = _sut
                    .GetHandlersFor(typeof(IGenerateEmailMessage))
                    .Single(imp => imp.ComponentModel.Implementation == typeof(EmailMessageGenerator));
                Assert.That(handler, Is.Not.Null);
            }
        }
    }
