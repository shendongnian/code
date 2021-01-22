    public class ViewModel
    {
        public ViewModel(IWebService service)
        {
            this.WebService = service;
        }
        public IEnumerable<SomeData> MyData { get; set; }
        public void DoIt()
        {
            this.GetReferenceData();
        }
        private IWebService WebService { get; set; }
        private void GetReferenceData()
        {
            this.WebService.BeginGetStaticReferenceData(GetReferenceDataOnComplete, null);
        }
        private void GetReferenceDataOnComplete(IAsyncResult result)
        {
            this.MyData = this.WebService.EndGetStaticReferenceData(result);
        }
    }
