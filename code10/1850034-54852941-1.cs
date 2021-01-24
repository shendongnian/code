    public class CountryController : Controller
    {
        [Route("{country}")]
        public string CountryPage(string country)
        {
            return country;
        }
    }
