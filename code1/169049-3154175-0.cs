    private List<SelectListItem> GetObjectList<ObjectType>(int id, Func<List<ObjectType>> getObjects)
    {
        List<ObjectType> apps = getObjects();
        List<SelectListItem> dropdown = apps.ConvertAll(c => new SelectListItem
        {
            Selected = c.Id == id,
            Text = c.Name,
            Value = c.Id.ToString()
        }).ToList();
        dropdown.Insert(0, new SelectListItem());
        return dropdown;
    }
    private List<SelectListItem> GetDeskList(int deskId)
    {
        return GetObjectList(deskId, (() -> Model.GetDesks()));
    }
    private List<SelectListItem> GetRegionList(int regionId)
    {
        return GetObjectList(regionId, (() -> Model.GetRegions()));
    }
