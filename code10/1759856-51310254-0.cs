    var coverageQuery = 
        _repository.LogicalEcus
            .Where(ecu => ecu.Alias != null)
            .Select(ecu => ecu.Alias)
            .Where(ecuAlias => searchTerm == "" || ecuAlias.Mnemonic.Contains(searchTerm.ToUpper()))
            .OrderBy(ecuAlias => ecuAlias.Mnemonic)
            .Select(x => x.Mnemonic)
            // Materialises and runs query. Rest is processed against objects.
            // Any method that runs after this line but not before can be
            // transformed into SQL equivalent
            .AsEnumerable()    
            .Distinct()
            .Select(mnemonic => new Select2Result(mnemonic));
