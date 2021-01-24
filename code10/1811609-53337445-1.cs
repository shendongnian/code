    public JsonResult GetAllPanditBookList()
    {
        var plist= db.TB_PBooking.Select(hc => new 
		{ 
			hc.PB_ID, 
			hc.PB_PRICE, 
			hc.PB_SPRICE, 
			hc.USER_ID,  
			hc.REG_DATE, 
			hc.STATUS,
			FinalPrice = hc.PB_PRICE * hc.PB_SPRICE /100,
			hc.PAYMENT_TYPE,
			hc.TB_UserReg.FULL_NAME,
			USERMOB = hc.TB_UserReg.MOBILE_NO 
		})
		.OrderByDescending(x => x.PB_ID)
		.ToList();
        return Json(_templeList, JsonRequestBehavior.AllowGet);
    }
