    IEnumerable<VmWordWithDictionary> ToVmWordWithDictionary(this IQueryable<VmWord> vmWords)
    {
         return vmWords.Select(vmWord => new VmWordEx()
         {
             Id = vmWord.Id,
             Name = vmWord.Name,
             Localizations = vmWord.VmWordLocalizatons
                 .Where(vmWordLocalization => ...)
                 .ToDictionary(
                     vmWordLocalization => vmWordLocalization.Key        // Key
                     vmWordLocalization => new VmWordLocalizationEx()    // Value
                     {
                          Id = vmWordLocalization.Id,
                          En = vmWordLocalization.Em,
                          Pl = vmWordLocalization.Pl,
                     }),
    });
