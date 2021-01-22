    public CatSubCatList GenerateCategoryListFromProductFeedXML()
    {
        string path = System.Web.HttpContext.Current.Server.MapPath(_xmlFilePath);
        XDocument xDoc = XDocument.Load(path);
        XElement xElement = XElement.Parse(xDoc.ToString());
        List<Category> lstCategory = xElement.Elements("Product").Select(d => new Category
        {
            Code = Convert.ToString(d.Element("CategoryCode").Value),
            CategoryPath = d.Element("CategoryPath").Value,
            Name = GetCateOrSubCategory(d.Element("CategoryPath").Value, 0), // Category
            SubCategoryName = GetCateOrSubCategory(d.Element("CategoryPath").Value, 1) // Sub Category
        }).GroupBy(x => new { x.Code, x.SubCategoryName }).Select(x => x.First()).ToList();
        CatSubCatList catSubCatList = GetFinalCategoryListFromXML(lstCategory);
        return catSubCatList;
    }
