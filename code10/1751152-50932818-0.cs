    public ActionResult deviceList(String sortBy, String Search)
            {
                if (Session["userID"] != null)
                {
                    ViewBag.SortNameParameter = String.IsNullOrEmpty(sortBy) ? "Name desc" : "";
                    ViewBag.SortTypeParameter = sortBy == "Type" ? "Type desc" : "Type";
                    ViewBag.SortManufacturerParameter = sortBy == "Manufacturer" ? "Manufacturer desc" : "Manufacturer";
                    var devices = db.devices.AsQueryable();
    
                    if (devices.Any(x => x.UserID == null))
                    {
                        devices = db.devices.Where(x => x.UserID == null);
    
                        switch (sortBy)
                        {
                            case "Name desc":
                                devices = devices.Where(x => x.DName.Contains(Search)).OrderByDescending(x => x.DName);
                                break;
                            ...
                            default:
                                devices = devices.Where(x => x.DName.Contains(Search)).OrderBy(x => x.DName);
                                break;
                        }
                        return View(devices.ToList());
                    }
