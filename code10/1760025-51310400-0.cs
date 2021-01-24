    IQueryable<Donneesource> RawDatas = _sourceDAL.Donneesource
        .Where(ic => ic.EstCopieDestination == false)
        .Where(s => PremierDateCom != DateTime.MinValue && s.SComPremierDate.Value.Date == PremierDateCom.Date)
        .Where(s => DerniereDateCom != DateTime.MinValue && s.SComDerniereDate.Value.Date == DerniereDateCom.Date)                    
        .Where(s => Secteur != string.Empty && s.SSectNom == Secteur);
    if (PremierDateCom != DateTime.MinValue)
    {
        RawDatas = RawDatas.Where(x => x.SComPremierDate.Value.ToShortDateString() == PremierDateCom.ToShortDateString());
    }
    if (DerniereDateCom != DateTime.MinValue)
    {
        RawDatas = RawDatas.Where(x => x.SComDerniereDate.Value.ToShortDateString() == DerniereDateCom.ToShortDateString());   
    }
    if (Secteur != null)
    {
        RawDatas = RawDatas.Where(x => x.SSectNom == Secteur);
    }
    //Now get the data from the database:
    return RawDatas.ToList();
