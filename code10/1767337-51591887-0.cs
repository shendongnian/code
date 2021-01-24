        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase filebase)
        {
            try
            {
                string fileName = string.Empty;
                string path; 
                if (filebase.ContentLength > 0)
                {
                    fileName = Path.GetFileName(filebase.FileName);
                    
                    path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    filebase.SaveAs(path);
					// Do stuff with the uploaded file
                }
			}
			catch (Exception){
				// Do whatever necessary to deal with the exception
			}
			
			return RedirectToAction("Index");
			
		}
