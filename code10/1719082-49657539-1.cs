        public ActionResult Wut()
        {
            Whatever wut = new Whatever();
            wut.Locations = new List<SelectListItem>();
            wut.Locations.Add(new SelectListItem { Text = "Uno", Value = "1" });
            wut.Locations.Add(new SelectListItem { Text = "Dos", Value = "2" });
            return View(wut);
        }
        public FileContentResult DownloadCSV(string location)
        {
            return File(new System.Text.UTF8Encoding().GetBytes("Generate, CSV, LOGIC, HERE, DEPENDING, ON, LOCATION"), "text/csv", "Example" + DateTime.Now.ToString("_MM-dd-yyyy-mm-ss-tt") + ".csv");
        }
