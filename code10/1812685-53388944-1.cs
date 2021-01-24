    public class SquirrelController : ApiController
    {
        [HttpPost]
        [Route("api/squirrels/search")]
        public SquirrelsResponse Squirrels(PostBody model)
        {
            var generator = new JSchemaGenerator();
            var schema = generator.Generate(typeof(SquirrelsRequest));
            var body = JObject.Parse(model.Body);
            bool valid = body.IsValid(schema, out IList<string> messages);
            if (!valid)
            {
                // Fail, do something
            }
            // Success
        }
    }
    public class PostBody
    {
        public string Body { get; set; }
    }
