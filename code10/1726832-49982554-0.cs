    Guid Id = Guid.Parse(e.CommandArgument.ToString());
    var yemekler = db.Yemekler.FirstOrDefault(y => y.ID == Id);
    if(yemekler != null)
    {
        var sepet = new Sepet() { ID = yemekler.ID }; //include other fields
        db.Sepet.Add(sepet);
        db.SaveChanges();
    };
