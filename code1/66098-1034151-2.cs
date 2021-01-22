    public void MapPersonToView(IEditPersonInfoView view, Person person)
    {
    	Gender gender = Gender.GetForDatabaseKey(person.Gender);
    	view.Gender = gender;
    	view.ShowMarriageSection = gender.CanGetMarriedInTexas(person.AgeInYears) ?? true;
    	// ...
    }
    
