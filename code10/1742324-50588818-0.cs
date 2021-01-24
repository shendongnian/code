        [HttpPost]
        public ActionResult CreateTenant(Tenanat tenanat)
        {
            //Master/Common DB
            using (DataContext ctx = new DataContext())
            {
                ctx.Tenanats.Add(tenanat);
                ctx.SaveChanges();
                string con = ConfigurationManager.ConnectionStrings["tenantContext"].ConnectionString;
                con = con.Replace("tenDbName", tenanat.Name.Trim());
               
                TenantContext tenantContext = new TenantContext(con,tenanat);
            }
            return RedirectToAction("Index", "Tenanat",tenanat);
        }
