        [Test]
        public void given_when_then()
        {
            Check.ThatCode(() => MethodToTest())
                .Throws<Exception>()
                .WithMessage("Process has been failed");
        }
