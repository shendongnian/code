    using System.ComponentModel;
    
    namespace RadioButtonMvvmDemo
    {
        public abstract class ViewModelBase : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            #endregion
    
            #region Protected Methods
    
            /// <summary>
            /// Raises the PropertyChanged event.
            /// </summary>
            /// <param name="propertyName">The name of the changed property.</param>
            protected void RaisePropertyChangedEvent(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                    PropertyChanged(this, e);
                }
            }
    
            #endregion
        }
    }
