    [Route("events")]
        [HttpPost]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            var _events= _context.Events.OrderBy(c => c.ProductID).ToList(); //yes, I know, I should use repository in the best practice
            return Json(_events);
        }
