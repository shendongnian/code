        [SwaggerOperationSummary("Add a new Pet to the store")]
        [SwaggerImplementationNotes("Adds a new pet using the supplied properties supplied in the model, returns a guid with the new pet id")]
        [Route("pets")]
        [HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            ...
        }
    
