    public class treeViewModel : INotifyPropertyChanged
    {
        public List<VersionViewModel> CurrentVersionViewModel { get; protected set; }
        public void AddNewVersionViewModel(VersionViewModel vvm)
        {
            CurrentVersionViewModel.Add(vvm);
            vvm.PropertyChanged += new PropertyChangedEventHandler(
                (obj,propEventArgs) => 
                    {
                    if (propEventArgs.PropertyName=="IsChecked")
                    {
                    // CheckedVersions change logic according to the new value (this is just the concept)
                        CheckedVersions += (obj as VersionViewModel).IsChecked;
                    }
                    }
                );
        }
        public string CheckedVersions { get { return _CheckedVersions; } set { _CheckedVersions = value; RaisePropertyChanged("CheckedVersions"); } }
        private string _CheckedVersions;
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(prop));
            }
        }
        #endregion
    }
    public class VersionViewModel : INotifyPropertyChanged
    {
        public bool IsChecked { get; set; }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
