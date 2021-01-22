    if (criteria.TaxCreditApprovalYear != null && criteria.TaxCreditApprovalYear.Count > 0)
    {
        Query qry1 = qry.And(Property_Overview.Columns.EffectiveDate)
                 .IsBetweenAnd(new DateTime(year, 01, 01), new DateTime(year, 12, 31)));
        Query qry2 = qry.And(Property_Overview.Columns.EffectiveDate)
                 .IsBetweenAnd(StartDate2, EndDate2));
        Query qry3 = qry.And(Property_Overview.Columns.EffectiveDate)
                 .IsBetweenAnd(StartDate3, EndDate3));
        criteria.TaxCreditApprovalYear.ForEach(year => qry1);
        criteria.TaxCreditApprovalYear.ForEach(year => qry2);
        criteria.TaxCreditApprovalYear.ForEach(year => qry3);
    }
