    public JsonResult gFbrRecord()
    {
        DataSet ds1 = dblayer.gfbrdata();
        List<fbrData> lstrng1 = new List<fbrData>(10000);
    
        //Your other stuff here
    
        DataSet ds2 = dblayer.gfbrdata();
        List<fbr1> lstrng2 = new List<fbr1>(10000);
    
        //Your other stuff here
    
        var result = (from item1 in lstrng1
                      select new
                      {
                          FBRInvoiceNumber = item1.FBRInvoiceNumber,
                          POSID = item1.POSID,
                          SRL_NUM = item1.SRL_NUM,
                          Data = (from item2 in lstrng2
                                  where item2.SRL_NUM == item1.SRL_NUM
                                  select new
                                  {
                                      DetailSerialNo = item2.DetailSerialNo,
                                      ItemCode = item2.ItemCode
                                  }).ToList()
                      }).ToList();
    
        return Json(result, "application/json", JsonRequestBehavior.AllowGet);
    }
