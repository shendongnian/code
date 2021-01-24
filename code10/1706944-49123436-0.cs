    public class ValidateController : Controller
    {
        [HttpPost("~/validate")]
        public IActionResult Index([FromBody]Parent parent)
        {
            return Json(new
            {
                IsValid = ModelState.IsValid,
                Errors = ModelState.Select(s => s.Value)
            });
        }
    }
    public class Parent : IValidatableObject
    {
        public string ParentName { get; set; }
        public Child Child { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ParentName == null)
            {
                yield return new ValidationResult("ParentName is null");
            }
        }
    }
    public class Child : IValidatableObject
    {
        public string ChildName { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ChildName == null)
            {
                yield return new ValidationResult("ChildName is null");
            }
        }
    }
