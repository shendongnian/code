    public override bool Equals(object obj){
    // Use 'as' rather than a cast to get a null rather an exception            
    // if the object isn't convertible           .
    Person person = obj as Person;            
    return this.Equals(person);        // wrong
    this.FirstName.Equals(person.FirstName)
    this.LastName.Equals(person.LastName)
    // and so on
    }
