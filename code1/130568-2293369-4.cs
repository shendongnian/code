    [Test]
        public void AddingToCollectionShouldHookPropertyChangedEventUp()
        {
            // Arrange: 
            var viewModel = new viewModel();
            var viewModelCollection = new viewModelCollection();
            // This *IS* your assert also, and will get called back when you Act
            // The only part you need to supply for this test is the property that gets fired when you add a viewmodel
            PropertyChangedEventHandler anonymousDelegate = (sender, e) => Assert.AreEqual("Whatever", e.PropertyName);
            // Subscribe to the needed event 
            viewModelCollection.PropertyChanged += anonymousDelegate;
            // Act: 
            viewModelCollection.AddViewModel(viewModel);
        }
