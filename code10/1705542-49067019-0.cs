    public ActionResult AssetRegisterIndex(string SearchString)
    {
      var assetregisters = from m in db.AssetRegisters
                                 select m;
    
      if (!String.IsNullOrEmpty(SearchString))
        {
               assetregisters = assetregisters.Where(s => s.AssetNumber.Contains(SearchString));
        }
    
       return Json(assetregisters,JsonRequestBehavior.AllowGet);
    }
