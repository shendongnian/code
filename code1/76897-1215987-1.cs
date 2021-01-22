    public void DoWork(IEnumerable<ICat> cats)
    {
      //do something 
    }
     List<PussyCat> pussyCats = new List<PussyCat>;
     List<OtherCat> otherCats = new List<OtherCat>;
     DoWork(pussyCats.OfType<ICat>);
     DoWork(otherCats.OfType<ICat>);
