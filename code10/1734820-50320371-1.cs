	public class RevisionMapModel : INotifyPropertyChanged
    {
        #region fields
        private Logger _logger = LogUtils.LogFactory.GetCurrentClassLogger();
        private string _parameter;
        public string Parameter
        {
            get { return _parameter; }
            set { }
        }
        private List<string> _revisions;
        public List<string> Revisions
        {
            get { return _revisions; }
            
        }
        private string _selection;
        public string Selection
        {
            get { return _selection; }
            set
            {
                _selection = value;
                OnPropertyRaised("Selection");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
		
        public RevisionMapModel(string parameter, List<string> revisions)
        {
            // set the parameter name and the list of revisions
            _parameter = parameter;
            _revisions = revisions;
            _selection = "";
            
            // add a default revision
            _revisions.Add("None");
            // attempt to find which revision matches with this parameter
            FullRevisionMatch(_parameter, _revisions);
            // if a full match isn't found, then try again
            if (_selection == "None")
            {
                PartialRevisionMatch(_parameter, _revisions);
            }
        }
		protected void OnPropertyRaised(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
   
	}
