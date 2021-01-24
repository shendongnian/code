        public async Task<IHttpActionResult> PostTenant(string id, Tenant tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await DocumentDBRepository<Tenant>.UpdateItemAsync(id, tenant);
            return StatusCode(HttpStatusCode.NoContent);
        }
