     [HttpPost]
        public ActionResult Save(Rent Rent , FileUpload upload, HttpPostedFileBase file)
        {
            if (Rent.Id == 0)
                _Context.Rent.Add(Rent);
            else
            {
                var rentInDb = _Context.Rent.Single(c => c.Id == Rent.Id);
                rentInDb.tenantId = Rent.tenantId;
                rentInDb.unitId = Rent.unitId;
                rentInDb.startDate = Rent.startDate;
                rentInDb.endDate = Rent.endDate;
                rentInDb.Amount = Rent.Amount;
                rentInDb.leaseStatus = Rent.leaseStatus;
                
            }
                _Context.SaveChanges();
           
            var rent = _Context.Rent.Single(r => r.Id == Rent.Id);
            var up = Request.Files["file"];
            if (up.ContentLength > 0) {
                var fileName = Path.GetFileName(file.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = Path.Combine(Server.MapPath("~/uploads"), guid + fileName);
                file.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                string imagepath = "~/uploads/" + newpath;
                upload.length = imagepath;
                upload.Rent = rent;
                _Context.FileUpload.Add(upload);
                _Context.SaveChanges();
            }
            return RedirectToAction("leaseStatus", "Home");
        }
