    public List<FDPGeschaefte> AlleGeschaefteZwischenBestimmtemDatum(string StartDatum, string EndDatum)
    {
        IQueryable<FDPGeschaefte> query = DB.FDPGeschaefte;
        if (StartDatum != null && EndDatum != null)
        {
            query = query.Where(i => i.SysCreated > DateTime.Parse(StartDatum) && i.SysCreated <= DateTime.Parse(EndDatum));
        }
        if (StartDatum != null)
        {
            query = query.Where(i => i.SysCreated >= DateTime.Parse(StartDatum));
        }
        if (EndDatum != null)
        {
            query = query.Where(i => i.SysCreated <= DateTime.Parse(EndDatum));
        }
        return query.ToList();
    }
