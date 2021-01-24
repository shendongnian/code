        public async Task<IHttpActionResult> PostTenant(string id, Tenant tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await DocumentDBRepository<Tenant>.UpdateItemAsync(id, tenant);
            return Ok(result);
        }
