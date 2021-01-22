    public class apBinding : Binding
    {
    
            public apBinding(string propertyName, INotifyPropertyChanged dataSource, string dataMember)
                : base(propertyName, dataSource, dataMember)
            {
               
                dataSource.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);
            }
            private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                this.ControlUpdateMode = ControlUpdateMode.Never;
                if (e.PropertyName == this.BindingMemberInfo.BindingField)
                {
                     this.ReadValue();
                }
            }
        }
