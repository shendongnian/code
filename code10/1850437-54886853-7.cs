        [HttpGet]
        [EnableQuery]
        [ODataRoute("Clients")]
        public async Task<IEnumerable<Client>> Get(
            ODataQueryOptions<Client> options,
            [FromRoute] Guid tenantId)
        {
            IQueryable res = await _service.Get(
                tenantId,
                AuthorizationHelper.GetSubjectId(tenantId, User),
                AuthorizationHelper.GetAllowedUserRoles(RoleType.Reporting),
                options,
                null);
            return new List<Client>(res.Cast<Client>());
        }
