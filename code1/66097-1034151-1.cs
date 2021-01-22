    public void MapViewToPerson(IEditPersonInfoView view, Person person)
    {
    	person.Gender = view.Gender.DatabaseKey;
    	// ...
    }
    
