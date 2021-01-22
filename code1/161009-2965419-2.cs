    query.Add(
      Restrictions.Or( 
        Restrictions.And(
          SqlExpression.CriterionFor<Engine>(e => e.StartMonth >= month),   
          SqlExpression.CriterionFor<Engine>(e => e.StartYear >= year)), 
        SqlExpression.CriterionFor<Engine>(e => e.StartYear >= year) ) );
