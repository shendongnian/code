    namespace WpfApp1.Models
    {
        using System.ComponentModel;
    
        public class Feature : INotifyPropertyChanged
        {
            public Feature()
            {
            }
    
            public Feature(string featureName, bool isSelected)
            {
                this.featureName = featureName;
                this.isSelected = isSelected;
            }
    
            private string featureName;
    
            public string FeatureName
            {
                get
                {
                    return featureName;
                }
    
                set
                {
                    if (featureName != value)
                    {
                        featureName = value;
                        RaisePropertyChanged("FeatureName");
                    }
                }
            }
    
            private bool isSelected;
    
            public bool IsSelected
            {
                get
                {
                    return isSelected;
                }
    
                set
                {
                    if (isSelected != value)
                    {
                        isSelected = value;
                        RaisePropertyChanged("IsSelected");
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void RaisePropertyChanged(string property)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }
    }
