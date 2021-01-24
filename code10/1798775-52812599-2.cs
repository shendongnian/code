    var vmWordsWithLocalizations = myDbContext.VmWords.Select(vmWord => new
    {
          // select only the properties you plan to use:
          Id = vmWord.Id,
          Name = vmWord.Name,
          Localizations.VmWord.VmwordLocalizations
              .Where(vmWordLocalization => ...) // only if you do't want all vmWordLocalizations
              .ToDictionary(vmWordLocalization => vmWordLocalization.Key,  // Dictionary Key
                  new                                                      // Dictionary value
                  {   // again: select only the properties you plan to use
                      Id = vmWordLocalization.Id,
                      En = vmWordLocalization.Em,
                      Pl = vmWordLocalization.Pl,
                      // no need: you know it equals vmWord.Id
                      // VmWordId = vmWordLocalization.VmWordId
 
                  }),
    });
