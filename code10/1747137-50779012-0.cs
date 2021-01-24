    // Property for binding SelectedItem from ListView.
    private Profile _selectedProfile;
    public Profile SelectedProfile
    {
        get { return _profiles; }
        set
        {
            _selectedProfile= value;
            OnPropertyChanged();
        }
    }
    // Command which we will use for Event to Command binding.
    public DelegateCommand ItemTappedCommand{ get; private set; }
    // ...
    // Code inside of the ctor in VM:
    ItemTappedCommand = new Command(ItemTapped);
    // ...
    
    // Method which will be executed using our command
    void ItemTapped()
    {
        // Here you can do whatever you want, this will be executed when
        // user clicks on item in ListView, you will have a value of tapped
        // item in SlectedProfile property
    }
