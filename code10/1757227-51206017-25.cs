    public class AutocompleteSourceController : ApiController
    {
        [HttpGet]
        public JsonResult<IEnumerable<MyClass>> GetItems(
            [FromUri]string term, 
            [FromUri]int[] selected)
        {
            // Load data
            // Fliter by term substring
            // Exclude selected items
            // Return the result
        }
    }
