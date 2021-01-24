    public class CatalogAvailabilityController
    {
        [HttpGet("GetSupportedCatalogsForCountry")]
        public List<string> GetSupportedCatalogsForCountry([FromUri] string countryCode)
        {
             //--return supported catalogs
        }
    }
