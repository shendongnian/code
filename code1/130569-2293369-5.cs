       [Test]
        public void Test()
        {
            var mockCorpseKicker = MockRepository.GenerateMock<INotifyPropertyChanged>();
            mockCorpseKicker.PropertyChanged += null;
            mockCorpseKicker.AssertWasCalled(x => x.PropertyChanged += Arg<PropertyChangedEventHandler>.Is.Anything);
        }
