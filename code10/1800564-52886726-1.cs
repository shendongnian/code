    // use the Identificacao if filter is null
    var isNull = Projections.SqlFunction("Coalesce"
        , NHibernate.NHibernateUtil.String
        , Projections.Constant(filtroRelatorio.MatriculaInicio)
        , Projections.Property(nameof(pacienteAlias.Identificacao))
    );
    queryOverPaciente
        .UnderlyingCriteria
        .Add(Restrictions.GeProperty(
            Projections.Property(nameof(pacienteAlias.Identificacao)),
            // the ISNULL projection instead of constant
            isNull
        ));
