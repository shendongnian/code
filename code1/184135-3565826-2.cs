    public AuswahlMap()
        {
            Table("AUSWAHL");
            Id(x => x.Id,"ID")
                .GeneratedBy.Sequence("SEQ_AUSWAHL");
            Map(x => x.Programm);
            Map(x => x.Variante);
            Map(x => x.Returnkey).Not.Nullable();
            Map(x => x.Beschreibung);
            HasMany(x => x.RefFilters)
                .Inverse()
                .Cascade.All();    
        }
    public RefAuswahlFilterMap()
        {
            Table("REFAUSWAHLFILTER");
            CompositeId()
                .KeyReference(x => x.Auswahl,"IDAUSWAHL")
                .KeyProperty(x => x.Filterrank);
            Map(x => x.Filter);
            References(x => x.Auswahl)
                .Column("IDAUSWAHL")
                .Not.Nullable();
        }
