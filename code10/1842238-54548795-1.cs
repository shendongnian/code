    public JsonResult IsProductNameExist(DbSet<T> dbSet,string Name, int? ID) where T : class, new()
        {
            var validateName = dbSet.FirstOrDefault
                                (x => x.Name == Name && x.ID != ID);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
