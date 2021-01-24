    [Produces("application/json")]
    public class SomethingController
    {
        [ProducesResponseType(typeof(YourObject), (int)HttpStatusCode.OK)]
        public IActionResult GetThing(int id)
        { ... }
    }
