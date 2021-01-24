    private List<Meb> GroupIdenticalMeb(List<Meb> mebInput)
    {
        List<Meb> retour = new List<Meb>();
        foreach(Meb mebOri in mebInput)
        {
            Meb meb = new Meb();
            meb.ID = -1;
            meb.Number = mebOri.Number;
            meb.Length = mebOri.Length;
            meb.Quantity=mebOri.Quantity;
            foreach(Repere repOri in mebOri.ListReperes)
            {
                Repere rep = new Repere();
                rep.Name = repOri.Name;
                rep.Quantite = repOri.Quantite;
                rep.ID = -1;
                meb.ListReperes.Add(rep);
            }
            retour.Add(meb);
            // Here I added a string property, in which I concatenate 
            //name and quantity of each Repere in my List<Repere>, 
            //so on the end the "SomeString" parameters will be identical
            //for all Meb that have the same List<Repere> (ignoring the IDs).
            foreach(Meb meb in retour)
            {
                meb.SomeString = "";
                foreach(RepereNest rep in meb.ListReperes)
                {
                    meb.SomeString += rep.Name + rep.Quantite;
                }
            }
            
    
        }
        retour = retour.GroupBy(l => l.SomeString)
                .Select(cl => new Meb
                {
                    ID=-1,
                    Number = cl.First().Number,
                    SomeString=cl.First().SomeString,
                    Length = cl.First().Length,
                    Quantity=cl.Sum(c => c.Quantity),
                    ListReperes = cl.First().ListReperes,
                }).ToList();
        return retour;
    }
