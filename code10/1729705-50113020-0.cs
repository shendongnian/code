    public Family SelectedFamily
    {
        set
        {
            var fam = new Family(
                new string(value.Name.ToCharArray()),
                new Person(value.Parent1.Name, value.Parent1.Age),
                new Person(value.Parent2.Name, value.Parent2.Age),
                new Person(value.Kid.Name, value.Kid.Age));
            _familyInfoGrid.Clear();
            _familyInfoGrid.Add(fam.Kid);
            _familyInfoGrid.Add(fam.Parent2);
            _familyInfoGrid.Add(fam.Parent1);
            RaisePropertyChangedEvent();
        }
    }
