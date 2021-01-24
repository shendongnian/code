    [HttpGet]
    [SwaggerOperation(nameof(GetAnimal))]
    [Route("{animalId:long}", Name = nameof(GetAnimal))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<AnimalModel>> GetAnimal(string tenantId, long animalId) {
        try {
            // Find the actual animal.. somewhere...using await.
    
            var model = new AnimalModel();
            //populate model    
            return model;
        } catch (Exception exception) {
            return InternalServerError(new ErrorModel());
        }
    }
