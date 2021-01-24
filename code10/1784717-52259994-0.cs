    internal sealed class CommonEventConsumer :
        IConsumer<Event1>,
        IConsumer<Event2>
    {
        private readonly ISomeService _someService;
        public CommonEventConsumer(ISomeService someService)
        {
            _someService = someService;
        }
        public async Task HandleEventAsync(Event1 eventMessage)
        {
            await _someService.DoSomeThing1(eventMessage);
        }
        public async Task HandleEventAsync(Event2 eventMessage)
        {
            await _someService.DoSomeThing2(eventMessage);
        }
    }
