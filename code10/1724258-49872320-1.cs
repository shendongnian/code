    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyname)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    private void button_Click(object sender, RoutedEventArgs e)
    {
        a++; //why does not it update the value in the UI?
        OnPropertyChanged("A");
    }
