     [HttpGet("{pageIndex}/{itemsPerPage}", Name = "GetBookWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Book>))]
        public async Task<ActionResult<PaginationResult<Book>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Book>();
                result = bookRepo.RetrieveBookWithPagination(page, itemsPerPage, filter);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
