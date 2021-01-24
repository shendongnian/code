    Guid Id = Guid.Parse(e.CommandArgument.ToString());
    var yemekler = db.Yemekler.FirstOrDefault(y => y.ID == Id);
    if(yemekler != null)
    {
        //after id, include other fields separated by comma
        var sepet = new Sepet() { ID = yemekler.ID };
        db.Sepet.Add(sepet);
        db.SaveChanges();
    };
