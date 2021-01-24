        public async Task<IHttpActionResult> PostTenant(string id, Tenant tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            /// Error is here
            return await DocumentDBRepository<Tenant>.UpdateItemAsync(id, tenant);
        }
