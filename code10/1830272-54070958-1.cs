    public ActionResult ListOfBrandNames(string id)
    {
        var result = db.Items.Where(x => x.Category.Name.Equals(id)).Select(x => x.BrandID).ToList();
        var ListOfBrands = db.Brands.Where(t => result.Contains(t.BrandID)).ToList();
        return RedirectToAction("BrandsOfACategory", new { brands = JsonConvert.SerializeObject(ListOfBrands) });
    }
