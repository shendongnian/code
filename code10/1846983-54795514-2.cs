    var filteredCenterCodeSends = dbContext.HISBaseCenterCodeSends
        .Include( ccs => ccs.Insur ) // assuming navigation property name
        .Where( ccs => 
            ccs.Center.CenterCode == 2 
            && ccs.ServiceGroup.ID == 4 );
            // if ccs.Insur/ID is nullable, also add `&& ccs.Insur != null`
    var insurersWithFilteredCcs = dbContext.HISBaseInsurs
        .GroupJoin( filteredCenterCodeSends,
            insr => insr,
            ccs => ccs.Insur,
            (insr, ccsCollection) =>
                new 
                {
                    Insur = insr,
                    FilteredCenterCodeSends = ccsCollection,
                } );
