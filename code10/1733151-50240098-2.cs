    public IEnumerable<BrandNameToIngredient> GetBrandNameToIngMapResults(string Keyword)
    {
        var brandNametoIngQuery = DB.USP_BRANDNAME_INGREDIENT_MAP()
                                 .Where(x => string.IsNullOrEmpty(Keyword) 
                                            || x.BrandName.Contains(Keyword, StringComparison.OrdinalIgnoreCase)        
                                            || x.PFCName.Contains(Keyword, StringComparison.OrdinalIgnoreCase)           
                                            || x.IngredientName.Contains(Keyword, StringComparison.OrdinalIgnoreCase)     
                                            || x.HCIngredientName.Contains(Keyword, StringComparison.OrdinalIgnoreCase))
                                 .Select(map=> new BrandNameToIngredient
                                 {
                                      IngredientBrandNameMapID = map.INGREDIENT_PRODUCT_MAP_ID,
                                      BrandName = map.FDA_BRAND_NAME,             //From Table 1              
                                      PFCName = map.PFC_DESC == null ? "" : map.PFC_DESC,  //From Table 1                        
                                      IngredientName = map.INGREDIENT_NAME,       //From Table 2
                                      HCIngredientName = map.HC_INGREDIENT_NAME,   //From Table 2                              
                                      KeywordfromPage = Keyword
                                  }).AsEnumerable();
    }
