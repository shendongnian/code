    var super = new List<Contact>();
    super.Add(new Contact() {Name = "John"});
    super.Add(new Contact() {Name = "Larry"});
    super.Add(new Contact() {Name = "Smith"});
    super.Add(new Contact() {Name = "Corey"});
    var sub = new List<Contact>();
    sub.Add(new Contact() {Name = "Larry"});
    sub.Add(new Contact() {Name = "Smith"});
    var subCount = 0;
    for(int i=0; i<super.Count && subCount < sub.Count; i++)
    {
        if (super[i].Name == sub[subCount].Name)
        {
            Act(super[i], sub[subCount]);
            subCount++;
        }
    }
