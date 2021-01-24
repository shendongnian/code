    private readonly ICatalogService _catalogService;
    
    // Dependency injection thanks to Inversion of Control
    public BlahController(ICatalogService catalogService){
         _catalogService=catalogService;
    }
    public async JsonResult GetCatalogs(params..){
         return await catalogService.getCatalogs(params..); //or catalogRepository
    }
