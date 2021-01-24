        public IActionResult GetGroupByService()
        {
            var grouping = _context.ComponentGroups;
            return Json(grouping);
        }
