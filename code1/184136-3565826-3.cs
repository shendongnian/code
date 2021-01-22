    public RefAuswahlFilterMap()
        {
            Table("REFAUSWAHLFILTER");
            CompositeId()
                .KeyReference(x => x.Auswahl,"IDAUSWAHL")
                .KeyProperty(x => x.Filterrank);
            Map(x => x.Filter);
        }
