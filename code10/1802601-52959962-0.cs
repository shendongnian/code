    public JsonResult PopulateModelDropDownList(StockBook.Models.StockBookContext _context, int selectedMakeID, object selectedModelID = null)
    {
        var ModelIDsQuery = from m in _context.VehicleModel
                            orderby m.ModelID // Sort by ID.
                            where m.MakeID == selectedMakeID
                            select m;
        ModelNameSL = new SelectList(ModelIDsQuery.AsNoTracking(),
                    "ModelID", "ModelName", selectedModelID);
        // return JSON string
        return new JsonResult(ModelNameSL);
    }
