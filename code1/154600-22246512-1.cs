    public class apBinding : Binding
    {
    
            public apBinding(string propertyName, INotifyPropertyChanged dataSource, string dataMember)
                : base(propertyName, dataSource, dataMember)
            {
                this.ControlUpdateMode = ControlUpdateMode.Never;
                dataSource.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);
            }
            private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                
                if (e.PropertyName == this.BindingMemberInfo.BindingField)
                {
                     this.ReadValue();
                }
            }
        }
