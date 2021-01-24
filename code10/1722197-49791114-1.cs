    public class FakeDisplay : IDisplay
    {
        public string LastDisplayedMessage => _lastDisplayedMessage;
          
        public void ShowMessage(string message)
        {
            _lastDisplayedMessage = message;
        }
    }
    [Test]
    public void WhenDoSomething_ShouldShowMessage()
    {
        var fakeDisplay = new FakeDisplay();
        var viewmodel = new ViewModel(fakeDisplay);
        viewmodel.DoSomething();
        fakeDisplay.LastDisplayedMessage.Should().Be("result of do something");     
    }
