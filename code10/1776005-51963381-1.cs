        public JsonResult Login(string Mail, string pass)
        {
            MessageType messageType = MessageType.InvalidEmail;
          
            using (DbNamesapce db = new DbNamesapce())
            {
                var query = // do Join
                            select new
                            {
                                //Select Something
                            };
                var user = query.FirstOrDefault();
                if (user == null)
                {
                    return Json(new { messageType = MessageType.InvalidEmail }, JsonRequestBehavior.AllowGet);
                }
                
                if (user != null && CheckPass)
                {
                    messageType = MessageType.Valid;
                }
                else
                {
                    messageType = MessageType.InvalidUerNameAndPass;
                }
                return Json(new { messageType = messageType }, JsonRequestBehavior.AllowGet);
            }
        }
