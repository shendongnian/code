    public event PropertyChangedEventHandler PropertyChanged;  
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")  
    {  
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public void UpdateView()
    {
        NotifyPropertyChanged("foo");
        NotifyPropertyChanged("bar");
    }  
...
    public static void Eval_Click(object sender, EventArgs e)
    {
        (this.DataContext as MyDataContext).UpdateView();
    }
