    [Test]
    public void ChangingTheWhateverProperty_TriggersPropertyChange()
        {
            // Create anonymous delegate which is also your test assertion
            PropertyChangedEventHandler anonymousDelegate = (sender, e) => Assert.AreEqual("Whatever", e.PropertyName);
            // Subscribe to the needed event
            vm.PropertyChanged += anonymousDelegate;
            // trigger the event
            vm.Whatever = "blah";
        }
