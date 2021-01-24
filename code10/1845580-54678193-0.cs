        [HttpPost]
        [Route("api/PostMaterialRequest")]        
        public IHttpActionResult PostMaterialRequest(List<ItemDto> items)
        {
            try
            {
                foreach (var i in items)
                {
                    _context.Items.Add(new Item()
                    {
                        MaterialId = i.MaterialId,
                        Description = i.Description,
                        Unit = i.Unit,
                        Quantity = i.Quantity,
                        MaterialRequestId = i.MaterialRequestId
                    });
                    _context.SaveChanges();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
