    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
       => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
 
    private string name;
    public string Name
    {
        get => name;
        set => SetField(ref name, value);
    }
