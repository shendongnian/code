    private void BookPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            OnPropertyChanged(string.Empty);
        }
    public void UpdateProperties()
        {
            OnPropertyChanged(string.Empty);
        }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
