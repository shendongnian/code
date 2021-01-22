       public DzieckoAndOpiekunCollection GetChildAndOpiekunByFirstnameLastname(string firstname, string lastname)
    {
        DataTransfer.ChargeInSchoolEntities db = new DataTransfer.ChargeInSchoolEntities();
        DzieckoAndOpiekunCollection result = new DzieckoAndOpiekunCollection();
        if (firstname == null && lastname != null)
        {
            IList<DzieckoAndOpiekun> resultV = from p in db.Dziecko
                          where lastname == p.Nazwisko
                          **select** new DzieckoAndOpiekun(
                         p.Imie,
                         p.Nazwisko,
                         p.Opiekun.Imie,
                         p.Opiekun.Nazwisko).ToList()
                      ;
            result.AddRange(resultV);
        }
        return result;
    }
