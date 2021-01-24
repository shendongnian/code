    public class CatalogAvailabilityController
    {
        [HttpGet]
        public List<string> GetSupportedCatalogsForCountry([FromUri] string countryCode)
        {
            //--return supported catalogs
        }
    }
