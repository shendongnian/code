    var ids = new HashSet<int>(facilityManagerId);
    foreach (PatchFacilityManager pfm in patchFacilityManager)
    {
        if (ids.Contains(pfm.FacilityManagerId))
            pfm.IsSelected = true;
    }
