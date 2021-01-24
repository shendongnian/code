    private void ChapterPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            OnPropertyChanged(string.Empty);
            
        }
    public void UpdateProperties()
        {
            OnPropertyChanged(string.Empty);
        }
