    public ActionResult Index()
        {
            string AssetGroupCode = "";
            string StatusCode = "";
            string SearchString = "";
            var mdl = from a in _db.Assets
                      join t in _db.Tags on a.ASSETID equals t.ASSETID
                      where a.ASSETGROUPCODE.Contains(AssetGroupCode)
                      && a.STATUSCODE.Contains(StatusCode)
                      && (
                      a.PO.Contains(SearchString)
                      || a.MODEL.Contains(SearchString)
                      || a.USERNAME.Contains(SearchString)
                      || a.LOCATION.Contains(SearchString)
                      || t.TAGNUMBER.Contains(SearchString)
                      || t.SERIALNUMBER.Contains(SearchString)
                      )
                      select new AssetListView
                      {
                          AssetId = a.ASSETID,
                          TagId = t.TAGID,
                          PO = a.PO,
                          Model = a.MODEL,
                          UserName = a.USERNAME,
                          Location = a.LOCATION,
                          Tag = t.TAGNUMBER,
                          SerialNum = t.SERIALNUMBER
                      };
            return View(mdl);
        }
