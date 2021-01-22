    public class ProjectListViewPresenter : Presenter<IProjectListView>
    {
        private ILookupService _lookupService;
     
        [ServiceDependency]
        public ILookupService LookupService
        {
            get { return _lookupService; }
            set { _lookupService = value; }
        }
    }
