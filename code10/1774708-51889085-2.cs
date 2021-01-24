            [HttpPost]
        public ActionResult Test([FromBody]PagedRequest<Product> input)
        {
            return Ok(new PagedRequest<Product> {
                    Page = 1,
                    PageSize = 100
            });
        }
