    private List<Genders> listOfGenders = new List<Genders>();
    
    public List<Genders> GenderList
    {
        get => listOfGenders;
        set 
        {
            listOfGenders = value;
            OnPropertyChanged(nameof(GenderList));
        }
    }
    
    private void AddToGenderList(params Gender[] genders)
    {
        if (listOfGenders == null)
        {
            listOfGenders = new List<Genders>();
        }
        
        foreach(Gender gender in genders)
        {
            listOfGenders.Add(gender);
        }
        
        GendersList = listOfGenders;
    }
