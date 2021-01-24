        [HttpGet]
        public IActionResult OnGetPart(string input)
        {
            var bellNumber = input.Split('_')[1];
            var partDetail = _context.Parts.FirstOrDefault(p => p.BellNumber == bellNumber);
            return new JsonResult(partDetail);
        }
