            // returns a list of space available based on section 
        [HttpGet]
        public ActionResult GetSpaceInfo(int sectionID)
        {
            List<Section> sect = new List<SSection>();
            //Should only return 1 item to the JSON list
            sect = _context.Sections.Where(m => m.Id == sectionID).ToList();
            return Json(sect);
        }
