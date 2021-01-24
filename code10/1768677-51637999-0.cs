    using System.Linq;
    ...
    var filter = new TaxiBriefingFilter();
    var dataFilter = new TrackDataFilter(new int[] { companyId }, null, from, to, userFirmRef);
    dataFilter.Jurisdictions.AddRange(
        filter.Jurisdictions.Select(jref => new TrackFilterGenericRef { Ref = jref }));
