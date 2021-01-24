        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<MainEntity>> GetMainEntities(int Id)
        {
            var result = _context.MainEtities
                .Include(x => x.MiddleEntities)
                    .ThenInclude(y => y.InnerEntities)
                .ToList();
            return Ok(result);
        }
