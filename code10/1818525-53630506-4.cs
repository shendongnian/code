    [TestFixture]
    public class ProcessFixture
    {
        private ILuisResult _luisResult;
        private BotHost _tested;
        private IDialogContext _dialogContext;
        private string _posted = null;
        [SetUp]
        public void SetUp()
        {
            _posted = null;
            _luisResult = Rhino.Mocks.MockRepository.GenerateMock<ILuisResult>();
            _dialogContext = Rhino.Mocks.MockRepository.GenerateMock<IDialogContext>();
            _dialogContext
                .Stub(x => x.PostAsync(Arg<string>.Is.Anything))
                .Do((Func<string, Task>) (s =>
                {
                    _posted = s;
                    return Task.Factory.StartNew(() => { });
                }));
            _tested = new BotHost(); //this is a made up class so I can call a method on it
        }
        [TestCase("", ExpectedResult = null)]
        [TestCase(":)", ExpectedResult = ":)")]
        [TestCase(": )", ExpectedResult = ":)")]
        public string ProcessCleansUpInputs(string input)
        {
            _luisResult.Stub(x => x.Query).Return(input);
            _tested.Process(_dialogContext, _luisResult).Wait();
            return _posted;
        }
    }
