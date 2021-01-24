    private HashSet<TPRelatedCase> AddOrUpdateCase(TPCase newCase, HashSet<TPRelatedCase> relatedCases)
    {
        if (newCase?.RelatedCases?.Count > 0)
        {
            relatedCases.UnionWith(newCase.RelatedCases);
        
            foreach (var relatedCase in newCase.RelatedCases)
            {
                if (relatedCase.RelatedCaseId.HasValue)
                {
                    var newRelatedCase = _integrationApiService.GetCase(relatedCase.RelatedBusinessSystemId, relatedCase.RelatedCaseId.Value);
        
                    for (int i = 0; i < newRelatedCase.RelatedCases.Count - 1; i++)
                    {
                        if (relatedCases.Any(x =>
                            x.BusinessSystemId == newRelatedCase.RelatedCases[i].BusinessSystemId && x.CaseId ==
                            newRelatedCase.RelatedCases[i].CaseId && x.RelationshipNo == newRelatedCase.RelatedCases[i].RelationshipNo))
                        {
                            newRelatedCase.RelatedCases.Remove(newRelatedCase.RelatedCases[i]);
                        }
                    }
        
                    relatedCases = AddOrUpdateCase(newRelatedCase, relatedCases);
                }
            }
        }
		//Need to clear RelatedCases due to the fact that circular references could happen and therefore a recursive method is not possible. 
        //Would lead to FOREIGN KEY constraint exception.
        newCase.RelatedCases = null;
        var current = _dbContext.Cases.Find(newCase.BusinessSystemId, newCase.CaseId);
        if (current == null)
        {
            _dbContext.Cases.Add(newCase);
        }
        else
        {
            _dbContext.Entry(current).CurrentValues.SetValues(newCase);
        }
        _dbContext.SaveChanges();
        return relatedCases;
	}
