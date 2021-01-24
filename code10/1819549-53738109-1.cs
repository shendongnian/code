    [HttpPost]
            public ActionResult EditUserAddress(UserAddress userAddress)
            {
                var model = PopulateProfileViewModel();
    
                if (!ModelState.IsValid)
                {
                    return PartialView("~/Views/User/Partials/_ProfileEditUserAddressPartial.cshtml", userAddress);
                }
    
                //some code...
    
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
