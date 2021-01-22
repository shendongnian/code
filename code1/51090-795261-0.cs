    State s = State.GetState("NY"); // here I do a load of a State class via the Linq DataContext
    County c = new County();
    c.Name = "Rockland";
    
    s.Counties.Add(c);
    db.SubmitChanges();
