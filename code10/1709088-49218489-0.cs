    public async Task<JsonResult> FetchTblData(AdminBundle abundleList)
    {
        AdminBundle abundle = new AdminBundle();
        string innerMesage = string.Empty;
        if (Session["AdminBundle"] != null)
            abundle = (AdminBundle)Session["AdminBundle"];
    
        //abundle.ListType = Request.Form["TblList"].ToString();
        abundle.ListType = abundleList.ListType;
    
        if (abundleList.ListType != string.Empty)
        {
            using (SMContext db = new SMContext())
            {
                switch (abundleList.ListType)
                {
                    case "Category":                 
                       var CategoryList =await db.CatObj.Where(x => x.Status_Info == Constants.StatusInfoOne).ToListAsync();
                        return Json { Data = CategoryList, JsonRequestBehavior.AllowGet };
                    //Class Starts
                    case "Board":
                       var BoardList =await db.BoardObj.Where(x => x.Status_Info == Constants.StatusInfoOne).ToListAsync();
                        return Json { Data = BoardList,  JsonRequestBehavior.AllowGet };
                   default:
                        return Json { Data = innerMesage,  JsonRequestBehavior.AllowGet };
                        //Main default Ends
                }
            }
        }
        else
        {
            return Json { Data = innerMesage,  JsonRequestBehavior.AllowGet };
        }
    }
