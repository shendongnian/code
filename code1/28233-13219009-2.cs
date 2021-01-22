    DataTable source { get; set; }
    String ValueMember { get; set; }
    String DisplayMember { get; set; }
    String FilterMember { get; set; }
    Object ADOSelect(Object criterium)
    {
        if ((source == null) || (criterium == null)) return null;
        return
        (
            from r in source.AsEnumerable()
            where (r[FilterMember] == criterium)
            select new
            {
                Value = r[ValueMember],
                Display = r[DisplayMember]
            }
        ).ToList();
    }
