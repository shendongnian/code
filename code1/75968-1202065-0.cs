    // NOTE: Is it just me or does this smell a little?
    if (criteria.TaxCreditApprovalYear != null && criteria.TaxCreditApprovalYear.Count > 0)
    {
        qry.AndExpression(Property_Overview.Columns.EffectiveDate)
           .IsBetweenAnd(new DateTime(criteria.TaxCreditApprovalYear[0], 01, 01), new DateTime(criteria.TaxCreditApprovalYear[0], 12, 31));
        // skip over the first index since we already set that up above in the AndExpression.
        for (int i = 1; i < criteria.TaxCreditApprovalYear.Count; i++)
        {
            qry.Or(Property_Overview.Columns.EffectiveDate)
               .IsBetweenAnd(new DateTime(criteria.TaxCreditApprovalYear[i], 01, 01), new DateTime(criteria.TaxCreditApprovalYear[i], 12, 31));
        }
    }
