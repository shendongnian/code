    using(MyDatabaseDataContext db = new MyDatabaseDataContext())
    {
        //LINQ will automatically pluralize your items (entity named Dog becomes Dogs)
        Dog d = db.Dogs.Where(x=>x.DogName.Equals(dogName));
        d.Owner = "Steve";
        db.SubmitChanges();
        //adding new items is easy too
        Dog newdog = new Dog();
        newDog.DogName = "Scruff";
        newDog.Owner = "Jim";
        db.Dogs.Add(newDog);
        db.SubmitChanges();
    }
