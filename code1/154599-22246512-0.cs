    public class apBinding : Binding
    {
    
            public apBinding(string propertyName, INotifyPropertyChanged dataSource, string dataMember)
                : base(propertyName, dataSource, dataMember)
            {
                this.ControlUpdateMode = ControlUpdateMode.Never;
                this.BindingComplete += new BindingCompleteEventHandler(OnapBindingComplete);
                dataSource.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);
            }
            private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == this.BindingMemberInfo.BindingField)
                {
                     ReadValue();
                }
            }
            private void OnapBindingComplete( object sender, BindingCompleteEventArgs e)
            {
                ReadValue();
            }
        }
