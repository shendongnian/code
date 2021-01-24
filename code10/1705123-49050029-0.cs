        using (PasswordGenerationEntities db = new PasswordGenerationEntities())
        {
            db.Database.Log = Console.Write; 
            tblPassword newObj = (from c in db.tblPasswords
                                  where c.Username == obj.Username
                                  select c).First();
            if(newObj != null)
            {
                int num = r.Next();
                string newOtp = num.ToString();
                newObj.Otp = newOtp;
                db.SaveChanges();
                dbTime = DateTime.Now;
                Session["Username"] = newObj.Username.ToString();
                return RedirectToAction("ChangePassword");
            }
        }
