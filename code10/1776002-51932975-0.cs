    [HttpPost]
        public JsonResult Login(string Mail, string pass)
        {
            var status = true; 
            var hashedPass = PasswordSecurity.PasswordStorage.CreateHash(pass);
            using (DbNameSpace db = new DbNameSpace())
            {
                var query = from cbr in db.Contact_Business_Relation
                            join c in db.Contact on cbr.Contact_No_ equals c.Company_No_
    
                            join sa in db.Sales_Header on cbr.No_ equals sa.Sell_to_Customer_No_
                            join px in db.PX2 on c.E_Mail equals px.Email_ID
    
                            where c.E_Mail == Mail.ToLower()
                            select new
                            {
                                Mail = c.E_Mail,
                                pass = px.PS,
    
                            };
    
                var user = query.FirstOrDefault();
                var CheckPass = PasswordSecurity.PasswordStorage.VerifyPassword(pass, user.pass);
    
                if (user != null && CheckPass) //Checkpassword
                {
    
                    Session["Email"] = user.Mail.ToString();
    
                }
    
         else {
                    status = false;                
             }
    
                return Json(status, JsonRequestBehavior.AllowGet);
            }
    
    
        }
