        [SwaggerOperationSummary("Add a new Pet to the store")]
        [SwaggerImplementationNotes("Adds a new pet using the properties supplied, returns a GUID reference for the pet created.")]
        [Route("pets")]
        [HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            ...
        }
    
