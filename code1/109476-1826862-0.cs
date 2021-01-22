    public partial class MainPage : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged( string propertyName )
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }   
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            c.Add(new Customer{_nome = "Maiara",_idade = "18"});   
            OnPropertyChanged("MyList"); // This only works if you use bindings.
        }
    }
      
