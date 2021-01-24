    public JsonResult GetContactInfo()
            {
                List<Contact> _contactLst = new List<Contact>();
                if (relid > 0)
                {
                    _contactLst = GetAllContactInfo();
                    if (_contactLst.Any())
                    {
                        return Json(_contactLst, JsonRequestBehavior.AllowGet);
                    }
                }
                return new List<Contact>();
    }
