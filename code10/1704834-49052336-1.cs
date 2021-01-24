        /// <summary>
        /// This action have an Integer parameter and redirect to action with alias
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var professional = await _context.professional 
                .SingleOrDefaultAsync(m => m.id == id);
            if (professional == null)
            {
                return NotFound();
            }
            RedirectResult redirectResult = new RedirectResult("/"+professional.alias);
            return redirectResult;
        }
        /// <summary>
        /// This action show detail view from alias parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DetailsAlias(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var professional= await _context.professional.SingleOrDefaultAsync(m => m.alias == id);
            if (professional== null)
            {
                return NotFound();
            }
            return View("Details", professional);
        }
