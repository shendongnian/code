    public class MonitorPageViewModel : DockPaneViewModel {
        public MonitorPageViewModel(ILogger logger, IRepository<RawMessage> repository,
            IRepository<Parser> parserRepository, IParsingService parsingService, 
            IPaneFactory factory) {
            // ...
        }
        public void CreateDashboard() {
            var dashBoardVm = factory.Create<MonitorDashboardViewModel>();
            
            //...
        }
    }
