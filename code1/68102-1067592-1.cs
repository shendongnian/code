    var person = PersonRespository.FindByName("Bevan");
    ...
    var copy = new Person();
    copy.Assign(person);
    using (var form = new PersonDataEntryForm(copy))
    {
        if (form.ShowAsModelessDialog() == MessageReturn.Save)
        {
            person.Assign(copy);
        }
    }
