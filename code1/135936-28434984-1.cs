    public class SI_MyProgressionHelper : INotifyPropertyChanged
    {
        private string _gstr_OverallProgress_Description = "";
        public string gstr_OverallProgress_Description { get { return _gstr_OverallProgress_Description; } set { _gstr_OverallProgress_Description = value; RaisePropertyChanged("gstr_OverallProgress_Description"); } }   
        private int _gint_OverallProgress_ActualValue = 0;
        public int gint_OverallProgress_ActualValue { get { return _gint_OverallProgress_ActualValue; } set { _gint_OverallProgress_ActualValue = value; RaisePropertyChanged("gint_OverallProgress_ActualValue"); } }   
        private int _gint_OverallProgress_MaximumValue = 9999;
        public int gint_OverallProgress_MaximumValue { get { return _gint_OverallProgress_MaximumValue; } set { _gint_OverallProgress_MaximumValue = value; RaisePropertyChanged("gint_OverallProgress_MaximumValue"); } }   
        protected virtual void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
