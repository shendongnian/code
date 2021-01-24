    public void AddOrUpdateNewInformation(InformationToGet info)
    {
        AddOrUpdatePossibleForeignKeys(info);
        var comparer = new TPRelatedCaseComparer();
        var relatedCases = new HashSet<TPRelatedCase>(comparer);
        _logger.Info($"Started updating cases");
        foreach (var infoCaseKey in info.CaseKeys)
        {
            var newCase = _integrationApiService.GetCase(infoCaseKey.BusinessSystemId, infoCaseKey.CaseId);
            AddOrUpdateCase(newCase, relatedCases);
            AddOrUpdateRelatedCases(relatedCases);
	    }
	}
