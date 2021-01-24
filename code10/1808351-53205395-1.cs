    private int currentSelectedIndex = 0;
    
    public int CurrentSelectedIndex
    {
        get => currentSelectedIndex;
        set
        {
            currentSelectedIndex = value;
            OnPropertyChanged(nameof(CurrentSelectedIndex));
        }
    }
    public MainViewModel()
    {
        AddToGenderList(new Gender[] 
        {
            new Gender
            {
                Name = "Male",
                Code = "M"
            },
            new Gender
            {
                Name = "Female",
                Code = "F"
            },
            new Gender
            {
                Name = "Other",
                Code = "O"
            }
            // Add more if necessary
        });
        
        // Set the default to "Male"
        CurrentSelectedIndex = 0;
    }
    
