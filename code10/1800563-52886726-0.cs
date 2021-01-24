    queryOverPaciente
        .UnderlyingCriteria
         // GeProperty will generate >=
        .Add(Restrictions.GeProperty(
            // column
            Projections.Property(nameof(pacienteAlias.Identificacao)),
            // constant
            Projections.Constant(filtroRelatorio.MatriculaInicio)
        ));
