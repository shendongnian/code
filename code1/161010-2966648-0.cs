    if (_searchCriteria.ProductionStart > 0)
    {
        int sYear = (int) Math.Floor( (double) _searchCriteria.ProductionStart / 100);
        int sMonth = _searchCriteria.ProductionStart % 100;
        query.Add(
            Restrictions.Or(
                Restrictions.And(
                    SqlExpression.CriterionFor<Engine>(e => e.StartMonth >= sMonth),
                    SqlExpression.CriterionFor<Engine>(e => e.StartYear >= sYear)
                ),
                SqlExpression.CriterionFor<Engine>(e => e.StartYear >= sYear)
            )
        );
    }
    if (_searchCriteria.ProductionEnd > 0)
    {
        int eYear = (int)Math.Floor((double)_searchCriteria.ProductionEnd / 100);
        int eMonth = _searchCriteria.ProductionEnd % 100;
        query.Add(
            Restrictions.Or(
                Restrictions.And(
                    SqlExpression.CriterionFor<Engine>(e => e.FinishMonth <= eMonth),
                    SqlExpression.CriterionFor<Engine>(e => e.FinishYear <= eYear)
                ),
                SqlExpression.CriterionFor<Engine>(e => e.FinishYear <= eYear)
            )
        );
    }
